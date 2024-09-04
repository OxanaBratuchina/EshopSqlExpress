using Eshop.DataBase;
using Eshop.Models;
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
            var dbOrder = dbContext.Order.FirstOrDefault(o => o.Id == id);
            Assert.NotNull(dbOrder);
            Assert.Equal(expectedState, dbOrder.State);
        }

        public static void NotExistOrderWithClientName(EshopContext dbContext, string clientName)
        {
            var dbOrder = dbContext.Order.FirstOrDefault(o => o.ClientName == clientName);
            Assert.Null(dbOrder);
        }
        public static void ExistOrderWithClientName(EshopContext dbContext, string clientName)
        {
            var dbOrder = dbContext.Order.FirstOrDefault(o => o.ClientName == clientName);
            Assert.NotNull(dbOrder);
        }

    }
}
