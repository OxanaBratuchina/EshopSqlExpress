namespace Eshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public double Price { get; set; }
        public double Count { get; set; }
        public List<Order> Orders { get; set; } = new();

         public List<OrderProduct> OrderProducts { get; set; } = new();

    }


}
