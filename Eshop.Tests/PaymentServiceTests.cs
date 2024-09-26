using Eshop.Data;
using Eshop.DataBase;
using Eshop.Models;
using Eshop.Services;
using Eshop.Tests.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;


namespace Eshop.Tests
{
    public class PaymentServiceTests
    {
        private const int WaitTimeOut = 5000;
        Mock<IServiceProvider> _serviceProvider = new Mock<IServiceProvider>();
        public PaymentServiceTests() 
        {

            //https://stackoverflow.com/questions/44336489/moq-iserviceprovider-iservicescope
            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(_serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory
                .Setup(x => x.CreateScope())
                .Returns(serviceScope.Object);

            _serviceProvider
                .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
                .Returns(serviceScopeFactory.Object);
        }


        [Fact]
        public async Task PaymentService_Start_SetPayedForOrder1Async()
        {
            // arrange

            int orderId = 1;            
            DbContextHelper dbTestContext = new DbContextHelper();
            dbTestContext.AddOrder(orderId);

            _serviceProvider
                .Setup(x => x.GetService(typeof(EshopContext)))
                .Returns(dbTestContext.EshopContext);


            PaymentQueue paymentQueue = new();
            paymentQueue.Enqueue(new PaymentInfo(orderId, true));
            ManualResetEvent dbEvent = new(false);

            int countOfPayment = 1;
            dbTestContext.EshopContext.SavedChanges += (sender, e) => _dbContext_SavedChanges(sender, e, dbEvent, ref countOfPayment);

            var paymentService = new PaymentService(paymentQueue, _serviceProvider.Object);

            // act
            await paymentService.StartAsync(CancellationToken.None);
            dbEvent.WaitOne(WaitTimeOut);

            // assert
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId, OrderState.Payd);
        }

        [Fact]
        public async Task PaymentService_Start_TwoPaymentsAsync()
        {
            // arrange
            int orderId1 = 1;
            int orderId2 = 2;
            DbContextHelper dbTestContext = new DbContextHelper();
            dbTestContext.AddOrder(orderId1);
            dbTestContext.AddOrder(orderId2);
            _serviceProvider
                .Setup(x => x.GetService(typeof(EshopContext)))
                .Returns(dbTestContext.EshopContext);


            PaymentQueue paymentQueue = new();
            paymentQueue.Enqueue(new PaymentInfo(orderId1, true));
            paymentQueue.Enqueue(new PaymentInfo(orderId2, false));

            int countOfPayment = 2;
            ManualResetEvent dbEvent = new(false);
            dbTestContext.EshopContext.SavedChanges += (sender, e) => _dbContext_SavedChanges(sender, e, dbEvent, ref countOfPayment);

            var paymentService = new PaymentService(paymentQueue, _serviceProvider.Object);

            // act
            await paymentService.StartAsync(CancellationToken.None);
            dbEvent.WaitOne(WaitTimeOut);

            // assert
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId1, OrderState.Payd);
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId2, OrderState.Rejected);
        }



        [Fact]
        public async Task PaymentService_Start_ThreePayments_OneNotFoundAsync()
        {
            // arrange
            int orderId1 = 1;
            int orderId2 = 2;
            DbContextHelper dbTestContext = new DbContextHelper();
            dbTestContext.AddOrder(orderId1);
            dbTestContext.AddOrder(orderId2);
            _serviceProvider
                .Setup(x => x.GetService(typeof(EshopContext)))
                .Returns(dbTestContext.EshopContext);

            PaymentQueue paymentQueue = new();
            paymentQueue.Enqueue(new PaymentInfo(orderId1, true));
            paymentQueue.Enqueue(new PaymentInfo(100, true));
            paymentQueue.Enqueue(new PaymentInfo(orderId2, false));

            int countOfPayment = 2;
            ManualResetEvent dbEvent = new(false);
            dbTestContext.EshopContext.SavedChanges += (sender, e) => _dbContext_SavedChanges(sender, e, dbEvent, ref countOfPayment);

            var paymentService = new PaymentService(paymentQueue, _serviceProvider.Object);

            // act
            await paymentService.StartAsync(CancellationToken.None);
            dbEvent.WaitOne(WaitTimeOut);

            // assert
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId1, OrderState.Payd);
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId2, OrderState.Rejected);
        }
        [Fact]
        public async Task PaymentService_Start_TwoPaymentsWithDelayAsync()
        {
            // arrange
            int orderId1 = 1;
            int orderId2 = 2;
            DbContextHelper dbTestContext = new DbContextHelper();
            dbTestContext.AddOrder(orderId1);
            dbTestContext.AddOrder(orderId2);
            _serviceProvider
                .Setup(x => x.GetService(typeof(EshopContext)))
                .Returns(dbTestContext.EshopContext);

            PaymentQueue paymentQueue = new();
            paymentQueue.Enqueue(new PaymentInfo(orderId1, true));

            int countOfPayment = 1;
            ManualResetEvent dbEvent = new(false);
            dbTestContext.EshopContext.SavedChanges += (sender, e) => _dbContext_SavedChanges(sender, e, dbEvent, ref countOfPayment);

            var paymentService = new PaymentService(paymentQueue, _serviceProvider.Object);

            // act
            await paymentService.StartAsync(CancellationToken.None);
            dbEvent.WaitOne(WaitTimeOut);

            // arrange
            countOfPayment = 1;
            dbEvent.Reset();
            paymentQueue.Enqueue(new PaymentInfo(orderId2, false));


            // act
            dbEvent.WaitOne(WaitTimeOut);

            // assert
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId1, OrderState.Payd);
            Validator.ValidateOrder(dbTestContext.EshopContext, orderId2, OrderState.Rejected);
        }

        
        private void _dbContext_SavedChanges(object? sender, SavedChangesEventArgs e, ManualResetEvent dbEvent, ref int count)
        {
            count--;
            if (count == 0)
                dbEvent.Set();
        }
    }
}