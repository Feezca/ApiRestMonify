using CurrencyConverter.Data.Entities;
using CurrencyConverter.Data.Models.Dtos;
using CurrencyConverter.Data.Models.Enum;
using CurrencyConverter.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CurrencyConverter.Data.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly CurrencyConverterContext _currencyContext;
        public UserService(CurrencyConverterContext currencyContext)
        {
            _currencyContext = currencyContext;
        }

        public List<User> GetAllUsers() 
        {
            return _currencyContext.Users.ToList();
        }
        public UserDto? GetUser(int id)
        {
            var user = _currencyContext.Users.SingleOrDefault(u => u.Id == id);
            if (user is not null)
            {
                return new UserDto()
                {
                    Username = user.Username,
                    State = user.State,
                    Conversions = user.Conversions,
                    Email = user.Email,
                    Id = user.Id,
                    Role = user.Role,
                    Plan = user.Plan,
                };
            }
            return null;
        }
        public void Create(CreateUserDto dto)
        {
            User newUser = new User()
            {
                Password = dto.Password,
                Username = dto.Username,
                Email = dto.Email,
                Currencies = new List<UserCurrency>()
            };
            _currencyContext.Users.Add(newUser);
            _currencyContext.SaveChanges();
        }

        public User? ValidateUser(AuthenticationRequestBodyDto authRequestBody)
        {
            return _currencyContext.Users.FirstOrDefault(p => p.Username == authRequestBody.Username && p.Password == authRequestBody.Password);
        }

        public void LogicalDelete(int id)
        {
            User? user = _currencyContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.State = UserStateEnum.Inactive;
            }
            _currencyContext.SaveChanges();
        }
        public void UpdatePlan(UpdateUserPlanDto dto, int Id)
        {
            User userToUpdate = _currencyContext.Users.First(u => u.Id == Id);
            userToUpdate.Plan = dto.Plan;
            userToUpdate.Conversions = dto.Conversions;

            _currencyContext.SaveChanges();
        }
        public void ConversionCounter(int Id)
        {
            User UserConversionCounter = _currencyContext.Users.SingleOrDefault(u => u.Id == Id);
            UserConversionCounter.Conversions++;
            _currencyContext.SaveChanges();
        }
        public bool CheckIfUserExists(int userId)
        {
            User? user = _currencyContext.Users.FirstOrDefault(user => user.Id == userId);
            return user != null;
        }

    }
}
