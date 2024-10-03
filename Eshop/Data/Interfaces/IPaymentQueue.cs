namespace Eshop.Data.Interfaces
{
    public interface IPaymentQueue
    {
        void Enqueue(PaymentInfo pi);
        Task<PaymentInfo> DequeueAsync(CancellationToken cancellationToken = default);
    }
}
