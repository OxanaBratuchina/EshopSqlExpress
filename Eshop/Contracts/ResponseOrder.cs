using System.Xml.Linq;
using Eshop.Data;
using Eshop.Models;

namespace Eshop.Contracts
{
    public class ResponseOrder

    {
        /// <summary>
        /// order id
        /// </summary>
        public int Id { get; set; }
        public string? ClientName { get; set; }

        public DateTime DateOfCreation { get; set; }

        public OrderState State { get; set; }

        public List<RequestProduct> Products { get; set; } = new();

        public override string ToString()
        {
            return $"Id:{Id}" + Helpers.ToStringParamsSeparator +
                $"ClientName:{ClientName}" + Helpers.ToStringParamsSeparator +
                 $"DateOfCreationId:{DateOfCreation}" + Helpers.ToStringParamsSeparator +
                  $"State:{State}" + Helpers.ToStringParamsSeparator +
                $"Products: {Products.ArrayToString()}"
                ;
        }
    }
}
