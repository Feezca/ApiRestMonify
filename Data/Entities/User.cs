using CurrencyConverter.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyConverter.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int Conversions { get; set; } 
        public string Role { get; set; } = "User";
        public UserStateEnum State { get; set; } = UserStateEnum.Active;
        public UserPlanEnum Plan { get; set; } = UserPlanEnum.Free;
        public List<UserCurrency>? Currencies { get; set; }
    }
}
