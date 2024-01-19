using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace CurrencyConverter.Data.Entities
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; } 
        public decimal ConvertibilityIndex  { get; set; }
        public string? Symbol { get; set; }
        public int UserId { get; set; }
        
        public List<UserCurrency>? Users{ get; set; }

    }
}
