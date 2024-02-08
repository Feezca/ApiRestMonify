using CurrencyConverter.Data.Models.Enum;

namespace CurrencyConverter.Data.Models.Dtos
{
    public class StateUserDto
    {
        public int Id { get; set; }
        public UserStateEnum UserState { get; set; }
    }
}
