using CurrencyConverter.Data.Models.Enum;

namespace CurrencyConverter.Data.Models.Dtos
{
    public class CreateUserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
