using CurrencyConverter.Data.Models.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace CurrencyConverter.Data.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int Conversions { get; set; }
        public UserPlanEnum Plan { get; set; }
        public UserStateEnum State { get; set; }
        public string Role { get; set; } = "User";

    }
}
