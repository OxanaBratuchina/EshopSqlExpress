using Eshop.Data;
using Eshop.Models;

namespace Eshop.Contracts
{
    public class RequestProduct
    {
        public RequestProduct() { }

        public RequestProduct(Product? product, double count, double price)
        {
            Name = product?.Name;
            Count = count;
            Price = price;
        }

        public RequestProduct(OrderProduct orderProduct)
        {
            Name = orderProduct.Product?.Name;
            Count = orderProduct.Count;
            Price = orderProduct.Price;
        }

        public string? Name { get; set; }
        public double Price { get; set; }

        public double Count { get; set; }

        public override string ToString()
        {
            return $"Name:{Name}" + Helpers.ToStringParamsSeparator +
                $"Price:{Price}" + Helpers.ToStringParamsSeparator +
                $"Count:{Count}"
                ;
        }
    }
}
