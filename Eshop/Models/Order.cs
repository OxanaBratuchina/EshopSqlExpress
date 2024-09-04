namespace Eshop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }

        public DateTime DateOfCreation { get; set; }

        public OrderState State { get; set; }

        public List<Product> Products { get; set; } = new();

        public List<OrderProduct> OrderProducts { get; set; } = new();
    }






}
