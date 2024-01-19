using CurrencyConverter.Data.Entities;
using CurrencyConverter.Data.Models.Dtos;
using CurrencyConverter.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CurrencyConverter.Data.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencyConverterContext _currencyContext;
        
        public CurrencyService(CurrencyConverterContext currencyContext)
        {
            _currencyContext = currencyContext;
        }

        public List<CurrencyDto> GetAll()
        {
            return _currencyContext.Currencies.Select(u => new CurrencyDto()
            {
                Id = u.Id,
                Name = u.Name,
                ConvertibilityIndex = u.ConvertibilityIndex,
                Symbol= u.Symbol
            }).ToList();
            
        }

        public void Create(CreateAndUpdateCurrencyDto dto)
        {
            Currency currency = new Currency()
            {
                Name = dto.Name,
                ConvertibilityIndex = dto.ConvertibilityIndex,
                Symbol = dto.Symbol,
                Users = new List<UserCurrency>()
            };
            _currencyContext.Currencies.Add(currency);
            _currencyContext.SaveChanges();
        }

        public void Update(CreateAndUpdateCurrencyDto dto, int Id )
        {
            Currency? currency = _currencyContext.Currencies.SingleOrDefault(currency => currency.Id == Id);
            if (currency != null)
            {
                currency.Name = dto.Name;
                currency.ConvertibilityIndex = dto.ConvertibilityIndex;
                currency.Symbol = dto.Symbol;
                _currencyContext.SaveChanges();
            }
        }
        

        public void Delete(int Id)
        {
            _currencyContext.Remove(_currencyContext.Currencies.Single(c => c.Id == Id));
            _currencyContext.SaveChanges();
        }
    }
}
