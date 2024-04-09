using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {
            var result = await _service.User.RegisterUser(userRegistration);

            if (!result.Succeeded)
            {
               return BadRequest(result.Errors);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto userLogin)
        {
            if (!await _service.User.AuthenticateUser(userLogin))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await _service.User.CreateToken() });
        }
    }
}
