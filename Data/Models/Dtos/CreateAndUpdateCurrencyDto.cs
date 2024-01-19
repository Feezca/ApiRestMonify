using CurrencyConverter.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Data.Models.Dtos
{
    public class CreateAndUpdateCurrencyDto
    {
        public string? Name { get; set; }
        public decimal ConvertibilityIndex { get; set; }
        public string? Symbol { get; set; }
    }
}
