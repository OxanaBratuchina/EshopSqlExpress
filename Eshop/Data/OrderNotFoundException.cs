namespace Eshop.Data
{
    public class OrderNotFoundException : Exception
    {
        private readonly int _orderId;
        public OrderNotFoundException(int orderId) { _orderId = orderId; }
        public override string Message
        {
            get
            {
                return $"Order with id={_orderId} has not been found";
            }
        }
    }
}
