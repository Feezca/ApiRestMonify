namespace CurrencyConverter.Data.Models.Dtos
{
    public class ConversionDto
    {
        public int UserId { get; set; }
        public decimal ConvertibilityIndexIn { get; set; }
        public decimal ConvertibilityIndexOut { get; set; }
        public decimal Amount { get; set; }     
        
    }
}
