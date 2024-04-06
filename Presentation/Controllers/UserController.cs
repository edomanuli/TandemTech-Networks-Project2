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
        
        public UserController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.User.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            var createdUser = await _service.User.CreateUserAsync(userDto);
            return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _service.User.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _service.User.GetUserAsync(id, trackChanges: false);
            return Ok(user);
        }
    }
}
