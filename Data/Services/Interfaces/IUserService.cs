using CurrencyConverter.Data.Entities;
using CurrencyConverter.Data.Models.Dtos;

namespace CurrencyConverter.Data.Services.Interfaces
{
    public interface IUserService
    {
        void LogicalDelete(int id);
        bool CheckIfUserExists(int userId);
        void Create(CreateUserDto dto);
        List<User> GetAllUsers();
        UserDto? GetUser(int id);
        void UpdatePlan(UpdateUserPlanDto dto, int userId);
        void ConversionCounter(int id);
        User? ValidateUser(AuthenticationRequestBodyDto authRequestBody);  
    }
}
