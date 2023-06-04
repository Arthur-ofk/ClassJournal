using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }
                return BadRequest();
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Autenticate([FromBody] UserForAuthenticationDto user )
        {
            if (!await  _service.AutentificationService.ValidateUser(user))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { Token = await _service.AutentificationService.CreateToken() });
            }
        }
    }
}
