using Eshop.Models;

namespace Eshop.Data
{
    public class QueryObject
    {
        public OrderState? OrderState { get; set; } = null;

        public string? Client { get; set; } = null;
    }
}
