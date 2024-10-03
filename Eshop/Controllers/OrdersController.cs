using Eshop.Contracts;
using Eshop.Data;
using Eshop.DataBase;
using Eshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly EshopContext _context;
        private IPaymentQueue _paymentQueue;

        public OrdersController(EshopContext context, IPaymentQueue paymentQueue)
        {
            _context = context;
            _paymentQueue = paymentQueue;
        }


        // GET: api/Orders
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ResponseOrder>))]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ResponseOrder>>> GetOrderAsync([FromQuery] QueryObject queryObject)
        {
            //return await _context.Order
            //    .AsNoTracking()
            //    .Select(
            //    dbo => new ResponseOrder()
            //    {
            //        ClientName = dbo.ClientName,
            //        CreatedAt = dbo.CreatedAt,
            //        State = dbo.State,
            //        Id = dbo.Id,
            //        Products = dbo.OrderProducts.Select(op => new RequestProduct(op.Product, op.Count, op.Price)).ToList()
            //    }

            //    ).ToListAsync().ConfigureAwait(false);


            var respOrders = _context.Order
                .AsNoTracking()
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Select(
                dbo => new ResponseOrder()
                {
                    ClientName = dbo.Client.Name,
                    DateOfCreation = dbo.CreatedAt,
                    State = dbo.State,
                    Id = dbo.Id,
                    Products = dbo.OrderProducts.Select(op => new RequestProduct(op)).ToList()
                }

                ).AsQueryable();
            //filtering 
            if (queryObject != null)
            {
                if (queryObject.OrderState.HasValue)
                {
                    respOrders = respOrders.Where(o => o.State == queryObject.OrderState);
                }
                if (!string.IsNullOrWhiteSpace(queryObject.Client))
                {
                    respOrders = respOrders.Where(o => !string.IsNullOrEmpty(o.ClientName) && o.ClientName.Contains(queryObject.Client));
                }
            }
            return await respOrders.ToListAsync().ConfigureAwait(false);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/payment")]
        [ProducesResponseType(202)]
        public IActionResult PostOrder(int id, PaymentRequest paymentRequest)
        {
            _paymentQueue.Enqueue(new PaymentInfo(id, paymentRequest.Payed));
            return Accepted();
        }

 

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ResponseOrder))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Order>> PostOrderAsync(RequestOrder order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var clientResult = Client.Create(order.ClientName, order.ClientEmail, order.ClientPhone);
            if (clientResult.IsFailure)
                return BadRequest(clientResult.Error);


            var orderResult = Order.Create(clientResult.Value, DateTime.Now, OrderState.New);
            if (orderResult.IsFailure)
                return BadRequest(orderResult.Error);
            _context.Order.Add(orderResult.Value);

            if (order.Products != null && order.Products.Count > 0)
            {
                foreach (var product in order.Products)
                {
                    if (product != null)
                    {
                        var dbProduct = _context.Product.FirstOrDefault(p => p.Name == product.Name);
                        if (dbProduct == null)
                        {
                            Console.WriteLine($"Product with name={product.Name} has not been found");
                            return StatusCode(StatusCodes.Status400BadRequest, new ProblemDetails { Detail = $"Product with name={product.Name} has not been found" });
                        }
                        if (dbProduct.Count < product.Count)
                        {
                            Console.WriteLine($"Product with id={dbProduct.Id}, name={product.Name} does not have enough resorces");
                            return StatusCode(StatusCodes.Status400BadRequest, new ProblemDetails { Detail = $"Product with id={dbProduct.Id}, name={product.Name} does not have enough resorces" });
                        }
                        dbProduct.OrderProducts.Add(new OrderProduct() { Order = orderResult.Value, Count = product.Count, Price = product.Price });
                    }
                }
            }
            var entries = _context.ChangeTracker.Entries(); //  Kiril for show context traking
            await _context.SaveChangesAsync().ConfigureAwait(false);


            //return Created((string?)null, dbOrder);
            return StatusCode(StatusCodes.Status201Created, new ResponseOrder()
                                {
                                    ClientName = orderResult.Value.Client.Name,
                                    DateOfCreation = orderResult.Value.CreatedAt,
                                    State = orderResult.Value.State,
                                    Id = orderResult.Value.Id,
                                    Products = orderResult.Value.OrderProducts.Select(op => new RequestProduct(op.Product, op.Count, op.Price)).ToList()
                                });
        }
    }
}
