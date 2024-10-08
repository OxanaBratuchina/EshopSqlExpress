﻿using Eshop.Data;
using Eshop.Data.Interfaces;
using Microsoft.VisualStudio.Threading;

namespace Eshop.Infrastructure
{
    public class PaymentQueue : IPaymentQueue
    {
        private AsyncQueue<PaymentInfo> _paymentQueue = new AsyncQueue<PaymentInfo>();

        public void Enqueue(PaymentInfo pi)
        {
            _paymentQueue.Enqueue(pi);
        }

        public Task<PaymentInfo> DequeueAsync(CancellationToken cancellationToken = default)
        {
            return _paymentQueue.DequeueAsync(cancellationToken);
        }
    }


}
