using CurrencyConverter.Data.Models.Dtos;
using CurrencyConverter.Data.Services.Implementations;
using CurrencyConverter.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService CurrencyService;
        private readonly IUserService UserService;

        public CurrencyController(ICurrencyService currencyService,IUserService userService)
        {
            CurrencyService = currencyService;
            UserService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(CurrencyService.GetAll());
        }

        [HttpPost]
        public IActionResult CreateCurrency(CreateAndUpdateCurrencyDto createCurrencyDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            CurrencyService.Create(createCurrencyDto);
            return Created("Created", createCurrencyDto);
        }

        
        [HttpPut]
        [Route("{currencyId}")]

        public IActionResult UpdateCurrency(CreateAndUpdateCurrencyDto dto,int currencyId)
        {
            try
            {
                CurrencyService.Update(dto, currencyId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{currencyId}")]
        public IActionResult Delete(int currencyId) 
        {
            try
            {
                CurrencyService.Delete(currencyId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
    }
}
