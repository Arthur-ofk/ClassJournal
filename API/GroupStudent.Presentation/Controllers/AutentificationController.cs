using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;
using System.ComponentModel.DataAnnotations;

namespace GroupStudent.Presentation.Controllers
{
    [Route("api/autentification")]
    [ApiController]
    public class AutentificationController : ControllerBase
    {
        public readonly IServiceManager _service;
        public AutentificationController(IServiceManager service) => _service = service ?? throw new ArgumentNullException(nameof(service));
        [HttpPost("register")]


        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result = await
            _service.AutentificationService.RegisterUser(userForRegistrationDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }
                return BadRequest();
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationAttribute))]
        public async Task<IActionResult> Autenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AutentificationService.ValidateUser(user))
            {
                return Unauthorized();
            }
            else
            {
                var tokenDto = await _service.AutentificationService.CreateToken(populateExp: true);
                return Ok(tokenDto);
            }
        }
    }
}
