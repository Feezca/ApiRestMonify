using CurrencyConverter.Data.Entities;
using CurrencyConverter.Data.Models.Dtos;
using CurrencyConverter.Data.Services.Implementations;
using CurrencyConverter.Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if(id < 0)
            {
                return BadRequest("El id ingresado debe ser mayor a 0");
            }
            UserDto? user= _userService.GetUser(id); 
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpPut("UpdatePlan/{userId}")]
        public IActionResult UpdateUserPlan(UpdateUserPlanDto dto, int userId)
        {
            if (!_userService.CheckIfUserExists(userId))
            {
                return NotFound();
            }
            try
            {
                _userService.UpdatePlan(dto, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
        [HttpPut("ConversorCounter/{id}")]
        public IActionResult ConversorCounter(int id)
        {
            // guardamos en una variable el momento de la conversion
            // DateTime fechaHoraActual = DateTime.Now;
            // Incrementa el contador
            _userService.ConversionCounter(id);
            return Ok();
        }


        [HttpPut("DeleteUser/{SubscriptId}")]
        public IActionResult DeleteUser (StateUserDto dto,int SubscriptId)
        {
            UserDto? user = _userService.GetUser(SubscriptId);
            if (user is null)
            {
                return BadRequest("El cliente que intenta eliminar no existe");
            }

            if (user.Role.ToString() != "Admin")
            {
                _userService.LogicalDelete(dto,SubscriptId);
            }
            return NoContent();
        }
    }
}
