using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [HttpGet("{id:int}", Name = "UserById")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _service.User.GetUserAsync(id, trackChanges: false);
            return Ok(user);
        }
    }
}
