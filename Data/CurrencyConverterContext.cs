using CurrencyConverter.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CurrencyConverter.Data
{
    public class CurrencyConverterContext :DbContext
    {
        
            public DbSet<Currency> Currencies { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<UserCurrency>UserCurrencies { get; set; }
        public CurrencyConverterContext(DbContextOptions<CurrencyConverterContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            User Admin = new User()
            {
                Id = 1,
                Username = "Admin",
                Password = "heisenberg",
                Email = "fecarrizzo@gmail.com",
                Role="Admin",
                State=Models.Enum.UserStateEnum.Active,
                Plan=Models.Enum.UserPlanEnum.Pro,
                Conversions=0
            };
            modelBuilder.Entity<User>().HasData(
                Admin);
            // Configuración de la relación muchos a muchos entre User y Currency
            modelBuilder.Entity<UserCurrency>()
                .HasKey(uc => new { uc.UserId, uc.CurrencyId });

            modelBuilder.Entity<UserCurrency>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Currencies)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCurrency>()
                .HasOne(uc => uc.Currency)
                .WithMany(c => c.Users)
                .HasForeignKey(uc => uc.CurrencyId);


            base.OnModelCreating(modelBuilder);
            }
        }
}
