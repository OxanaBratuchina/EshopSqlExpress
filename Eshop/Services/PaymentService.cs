
using Eshop.Data;
using Eshop.Data.Exceptions;
using Eshop.Data.Interfaces;
using Eshop.Infrastructure;
using Eshop.Models;
using Microsoft.Build.Experimental.FileAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Threading;
using System.Xml.Linq;

namespace Eshop.Services
{
    public class PaymentService : BackgroundService
    {
        private readonly IPaymentQueue _paymentQueue;
        private readonly IServiceProvider _serviceProvider;

        public PaymentService(IPaymentQueue paymentQueue, IServiceProvider serviceProvider)
        {
            _paymentQueue = paymentQueue ?? throw new ArgumentNullException(nameof(paymentQueue));
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    PaymentInfo paymentInfo = await _paymentQueue.DequeueAsync(stoppingToken).ConfigureAwait(false);
                    if (paymentInfo != null)
                    {
                        await UpdateOrderStateAsync(paymentInfo).ConfigureAwait(false);
                    }
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine($"Operation of payment queue element processing was canceled, message:{ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt to process payment queue element was unsuccessful, message:{ex.Message}");
                }
            }
        }
        private async Task UpdateOrderStateAsync(PaymentInfo paymentInfo)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EshopContext>();
                var order = dbContext.Order.Find(paymentInfo.OrderId);
                if (order == null)
                {
                    throw new OrderNotFoundException(paymentInfo.OrderId);
                }

                var changeResult = order.ChangeState(paymentInfo.Payed ? OrderState.Payd : OrderState.Rejected);
                if (changeResult.IsFailure)
                {
                    Console.WriteLine($"[{order.Id}] {changeResult.Error}");
                    return;
                }

                await dbContext.SaveChangesAsync().ConfigureAwait(false);

                Console.WriteLine($"[{order.Id}] Successful payment update to {order.State}");
            }
        }

    }
   /* public class PaymentService : IHostedService
    {
        private readonly IPaymentQueue _paymentQueue;
        private readonly EshopContext _dbContext;
        private Task? _executingTask;
        private CancellationTokenSource? _cts;
        public PaymentService(IPaymentQueue paymentQueue, EshopContext dbContext)
        {
            _paymentQueue = paymentQueue ?? throw new ArgumentNullException(nameof(paymentQueue));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cts = new CancellationTokenSource();

            _executingTask = Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    try
                    {
                        PaymentInfo paymentInfo = await _paymentQueue.DequeueAsync(_cts.Token).ConfigureAwait(false);
                        if (paymentInfo != null)
                        {
                            await ProcessDataAsync(paymentInfo).ConfigureAwait(false);
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine($"Operation of payment queue element processing was canceled, message:{ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Attempt to process payment queue element was unsuccessful, message:{ex.Message}");                        
                    }
                }
            }, _cts.Token);

            return Task.CompletedTask;
        }
        private async Task ProcessDataAsync(PaymentInfo paymentInfo)
        {
            var order = _dbContext.Order.FirstOrDefault(order => order.Id == paymentInfo.OrderId);
            if (order == null)
            {
                throw new OrderNotFoundException(paymentInfo.OrderId);
            }
                
            order.State = paymentInfo.Payed ? OrderState.Payd : OrderState.Rejected;

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            Console.WriteLine($"[{order.Id}] Successful payment update to {order.State}");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask == null)
            {
                return;
            }

            if (_cts != null)
            {
                Task cancellationTask = _cts.CancelAsync();

                await Task.WhenAny(cancellationTask, Task.Delay(TimeSpan.FromSeconds(5))).ConfigureAwait(false);
            }
        }

    }*/
}