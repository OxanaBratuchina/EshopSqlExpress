using System.ComponentModel.DataAnnotations;
namespace Eshop.Contracts
{
    public class LoginDto
    {
        [Required]
        public string? UserName { get; set; }


        [Required]
        public string? Password { get; set; }
    }
}
