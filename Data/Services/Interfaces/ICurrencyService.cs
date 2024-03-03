using CurrencyConverter.Data.Entities;
using CurrencyConverter.Data.Models.Dtos;

namespace CurrencyConverter.Data.Services.Interfaces
{
    public interface ICurrencyService
    {
        void Create(CreateAndUpdateCurrencyDto dto);
        void Delete(int currencyCode);
        List<CurrencyDto> GetAll();
        void Update(CreateAndUpdateCurrencyDto dto,int currencyCode);
        decimal Conversion(ConversionDto dto);
    }
}
