namespace CurrencyConverter.Data.Models.Dtos
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal ConvertibilityIndex { get; set; }
        public string? Symbol { get; set; }
    }
}
