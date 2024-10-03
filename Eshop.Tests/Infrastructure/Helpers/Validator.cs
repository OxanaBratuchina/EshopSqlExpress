using Eshop.Contracts;
using Eshop.Data;
using Eshop.Infrastructure;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Tests.Infrastructure.Helpers
{
    internal static class Validator
    {
        public static void ValidateOrder(EshopContext dbContext, int id, OrderState expectedState)
        {
            var records = dbContext.Order.Count();
            var dbOrder = dbContext.Order.Find(id);
            Assert.NotNull(dbOrder);
            Assert.Equal(expectedState, dbOrder.State);
        }

        public static void NotExistOrderWithClientName(EshopContext dbContext, string clientName)
        {
            var records = dbContext.Order.Count();

            var dbOrder = dbContext.Order.FirstOrDefault(o => o.Client.Name == clientName);
            Assert.Null(dbOrder);
        }
        public static void ExistOrderWithClientName(EshopContext dbContext, string clientName)
        {

                var condition = dbContext.Order.Where(o => o.Client.Name == clientName).ToList();
                var dbOrder = dbContext.Order.FirstOrDefault(o => o.Client.Name == clientName);
                Assert.NotNull(dbOrder);
        }

    }
}
