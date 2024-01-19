using CurrencyConverter.Data.Models.Enum;

namespace CurrencyConverter.Data.Models.Dtos
{
    public class UpdateUserPlanDto
    {
        public int Conversions { get; set; } 
        public UserPlanEnum Plan { get; set; }
    }
}
