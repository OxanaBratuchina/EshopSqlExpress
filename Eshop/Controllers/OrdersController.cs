using Eshop.Contracts;
using Eshop.Data;
using Eshop.DataBase;
using Eshop.Models;
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
        public async Task<ActionResult<IEnumerable<ResponseOrder>>> GetOrderAsync()
        {
            //return await _context.Order
            //    .AsNoTracking()
            //    .Select(
            //    dbo => new ResponseOrder()
            //    {
            //        ClientName = dbo.ClientName,
            //        DateOfCreation = dbo.DateOfCreation,
            //        State = dbo.State,
            //        Id = dbo.Id,
            //        Products = dbo.OrderProducts.Select(op => new RequestProduct(op.Product, op.Count, op.Price)).ToList()
            //    }

            //    ).ToListAsync().ConfigureAwait(false);

            return await _context.Order
                .AsNoTracking()
                .Include(o=>o.OrderProducts)
                .ThenInclude(op=> op.Product)
                .Select(
                dbo => new ResponseOrder()
                {
                    ClientName = dbo.ClientName,
                    DateOfCreation = dbo.DateOfCreation,
                    State = dbo.State,
                    Id = dbo.Id,
                    Products = dbo.OrderProducts.Select(op => new RequestProduct(op)).ToList()
                }

                ).ToListAsync().ConfigureAwait(false);
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
            var dbOrder = new Order() { ClientName = order.ClientName, DateOfCreation = DateTime.Now, State = OrderState.New };
            _context.Order.Add(dbOrder);

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
                        dbProduct.OrderProducts.Add(new OrderProduct() { Order = dbOrder, Count = product.Count, Price = product.Price });
                    }
                }
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);


            //return Created((string?)null, dbOrder);
            return StatusCode(StatusCodes.Status201Created, new ResponseOrder()
                                {
                                    ClientName = dbOrder.ClientName,
                                    DateOfCreation = dbOrder.DateOfCreation,
                                    State = dbOrder.State,
                                    Id = dbOrder.Id,
                                    Products = dbOrder.OrderProducts.Select(op => new RequestProduct(op.Product, op.Count, op.Price)).ToList()
                                });
        }
    }
}
