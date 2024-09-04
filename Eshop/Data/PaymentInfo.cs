namespace Eshop.Data
{
    public class PaymentRequest
    {
        public bool Payed { get; set; }
        public override string ToString()
        {
            return $"Payed:{Payed}";
        }
    }
    public class PaymentInfo : PaymentRequest
    {
        public int OrderId { get; set; }
        public PaymentInfo(int orderId, bool payed)
        {
            OrderId = orderId;
            Payed = payed;
        }
        public override string ToString()
        {
            return base.ToString() + Helpers.ToStringParamsSeparator + $"OrderId:{OrderId}";
        }

    }
}
