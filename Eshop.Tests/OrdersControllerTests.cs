using Eshop.Controllers;
using Eshop.Data;
using Eshop.DataBase;
using Eshop.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Eshop.Contracts;
using Eshop.Tests.Infrastructure.Helpers;


namespace Eshop.Tests
{
    public class OrdersControllerTests
    {

        public OrdersControllerTests()
        {

        }



        [Fact]
        public async Task OrdersController_PostOrderAsync_CreateNewOrderOk()
        {
            EshopContext dbContext = new DbContextHelper().EshopContext;
            // arrange
            PaymentQueue paymentQueue = new();
            var ordersController = new OrdersController(dbContext, paymentQueue);
            int clientTestId = 1;
            var client = TestClient.CreateTestClient(clientTestId);
            var requestOrder = new RequestOrder()
            {
                ClientName = client.Name,
                ClientEmail = client.Email.Value,
                ClientPhone = client.Phone.Value,
                Products = new List<RequestProduct>() { new RequestProduct() { Name = "Product1", Count = 15, Price = 10} }
            };

            // act
            var result = await ordersController.PostOrderAsync(requestOrder);


            // assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<Order>>();
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType<ObjectResult>();
            
            var ob = (ObjectResult)result.Result;
            ob.Should().NotBeNull();
            ob.Value.Should().NotBeNull();
            ob.Value.Should().BeOfType<ResponseOrder>();

            ob.StatusCode.Should().Be(StatusCodes.Status201Created);

            var resultOrder = (ResponseOrder)ob.Value;
            resultOrder.Should().NotBeNull();
            Validator.ValidateOrder(dbContext, resultOrder.Id, OrderState.New);
           
        }

        [Fact]
        public async Task OrdersController_PostOrderAsync_CreateNewOrderProductNotFound()
        {
            // arrange
            EshopContext dbContext = new DbContextHelper().EshopContext;
            PaymentQueue paymentQueue = new();
            var ordersController = new OrdersController(dbContext, paymentQueue);
            int clientTestId = 2;
            var client = TestClient.CreateTestClient(clientTestId);
            var requestOrder = new RequestOrder()
            {
                ClientName = client.Name,
                ClientEmail = client.Email.Value,
                ClientPhone = client.Phone.Value,
                Products = new List<RequestProduct>() { new RequestProduct() { Name = "Product100", Count = 15, Price = 10 } }
            };

            // act
            var result = await ordersController.PostOrderAsync(requestOrder);


            // assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<Order>>();
            result.Result.Should().NotBeNull();
            result.Result.Should().BeOfType<ObjectResult>();

            var ob = (ObjectResult)result.Result;
            ob.Should().NotBeNull();
            ob.Value.Should().NotBeNull();
            ob.Value.Should().BeOfType<ProblemDetails>();

            ob.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var problemDetails = (ProblemDetails)ob.Value;
            problemDetails.Should().NotBeNull();
            //Validator.NotExistOrderWithClientName(dbContext, client.Name);
            dbContext.Order.Count().Should().Be(0);
        }
    }
}
