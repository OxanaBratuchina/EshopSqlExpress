using System.ComponentModel.DataAnnotations;

namespace Eshop.Contracts
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; } = null;
        
        [Required]
        public string? Password { get; set; }
    }
}
