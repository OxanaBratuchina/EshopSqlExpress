using System.ComponentModel.DataAnnotations;
namespace Eshop.Contracts
{
    public class NewUserDto
    {
        public string UserName  { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
