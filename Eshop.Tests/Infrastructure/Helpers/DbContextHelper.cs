using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop.DataBase;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Eshop.Models;

namespace Eshop.Tests.Infrastructure.Helpers
{
    internal class DbContextHelper
    {
        private static int count = 0;
        public EshopContext EshopContext { get; set; }
        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<EshopContext>();
            builder.UseInMemoryDatabase("EshopTest"+(count++).ToString())
                
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;
            EshopContext = new EshopContext(options);

            EshopContext.AddRange(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Select(i => new Product()
            {
                Name = "Product" + i.ToString(),
                Price = 0.99 + i * 10,
                Count = 100
            }));
            EshopContext.SaveChanges();
        }

        public void AddOrder(int id)
        {
            int clientTestId = 1;
            var client = TestClient.CreateTestClient(clientTestId);
            var dbOrder = Order.Create(client, DateTime.Now, OrderState.New, id ).Value;
            EshopContext.Order.Add(dbOrder);
            var dbProduct = EshopContext.Product.FirstOrDefault(x => x.Name == "Product1");
            dbProduct.OrderProducts.Add(new OrderProduct() { Order = dbOrder, Count = 1, Price = 6 });
            EshopContext.SaveChanges();
        }
    }

}
