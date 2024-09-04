namespace Eshop.Data
{
    public class ProductNotEnoughtException : Exception
    {
        private readonly int _productId;
        private readonly string _productName;
        public ProductNotEnoughtException(int productId, string productName)
        {
            _productId = productId;
            _productName = productName;
        }
        public override string Message
        {
            get
            {
                return $"Product with id={_productId}, name={_productName} does not have enough resorces";
            }
        }
    }
    public class ProductNotFoundException : Exception
    {
        private readonly string _productName;
        public ProductNotFoundException(string productName)
        {
            _productName = productName;
        }
        public override string Message
        {
            get
            {
                return $"Product with name={_productName} has not been found";
            }
        }
    }
}
