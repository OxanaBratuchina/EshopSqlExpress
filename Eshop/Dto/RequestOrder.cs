using Eshop.Data;
using Eshop.Models;
using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Contracts
{
    public class RequestOrder
    {
        [Required]
        //[MinLength(3, ErrorMessage ="Client must have 3 characters")]
        //[MaxLength(200, ErrorMessage = "Client can not be over 200 characters")]
        [MaxLength(Client.NAME_MAX_LENGTH, ErrorMessage = "Client name is too long")]
        public string? ClientName { get; set; }
        [Required]
        public string? ClientEmail { get; set; }
        [Required]
        public string? ClientPhone { get; set; }

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
