using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Data.Models.Dtos
{
    public class AuthenticationRequestBodyDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
