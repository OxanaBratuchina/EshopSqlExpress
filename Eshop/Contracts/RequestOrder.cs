using Eshop.Data;
using Mono.TextTemplating;

namespace Eshop.Contracts
{
    public class RequestOrder
    {
        public string? ClientName { get; set; }

        public List<RequestProduct> Products { get; set; } = new();

        public override string ToString()
        {
            return
                $"ClientName:{ClientName}" + Helpers.ToStringParamsSeparator +
                $"Products: {Products.ArrayToString()}"
                ;
        }
    }
}
