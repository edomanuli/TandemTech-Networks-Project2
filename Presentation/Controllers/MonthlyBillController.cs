using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/user/bill")]
    [Authorize]
    public class MonthlyBillController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public MonthlyBillController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
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
        public async Task<IActionResult> GetUserBill()
        {
            int userId = GetUserId();
            var bills = await _serviceManager.MonthlyBill.GetUserBill(userId);
            return Ok(bills);
        }
    }

}
