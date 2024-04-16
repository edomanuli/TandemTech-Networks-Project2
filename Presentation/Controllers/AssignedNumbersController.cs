using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/user/numbers")]
    [Authorize]
    public class AssignedNumbersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AssignedNumbersController(IServiceManager service)
        {
            _service = service;
        }

        protected int GetUserId()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
            {
                throw new UnauthorizedAccessException("User ID is missing.");
            }

            if (!int.TryParse(userIdString, out int userId))
            {
                throw new ArgumentException("User ID is invalid.");
            }

            return userId;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDevices()
        {
            int userId = GetUserId();
            var numbers = await _service.AssignedNumber.GetAssignedNumbersByUserId(userId);
            return Ok(numbers); 
        }

    }

}
