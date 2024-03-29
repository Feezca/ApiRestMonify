﻿using CurrencyConverter.Data.Entities;
using CurrencyConverter.Data.Models.Dtos;

namespace CurrencyConverter.Data.Services.Interfaces
{
    public interface IUserService
    {
        bool CheckIfUserExists(int userId);
        void Create(CreateUserDto dto);
        List<User> GetAllUsers();
        UserDto? GetUser(int id);
        void UpdatePlan(UpdateUserPlanDto dto, int userId);
        void LogicalDelete(StateUserDto dto, int userId);
        User? ValidateUser(AuthenticationRequestBodyDto authRequestBody);  
    }
}
