namespace Eshop.Models
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public double Price { get; set; }

        public double Count { get; set; }
    }
}
