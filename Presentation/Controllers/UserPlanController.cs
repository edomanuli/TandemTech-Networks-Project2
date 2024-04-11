using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/user/plans")]
    [Authorize]
    public class UserPlanController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserPlanController(IServiceManager serviceManager)
        {
            _service = serviceManager;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUserPlans()
        {
            int userId = GetUserId();

            var plans = await _service.UserPlan.GetUserPlans(userId);
            return Ok(plans);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUserPlan(UserPlanCreateDto userPlanCreateDto)
        {
            int userId = GetUserId();
            var result = await _service.UserPlan.EnrollUserInPlan(userId, userPlanCreateDto);
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{userPlanId}")]
        public async Task<IActionResult> RemoveUserPlan(int userPlanId)
        {
            await _service.UserPlan.CancleUserPlan(userPlanId);
            return NoContent();
        }

    }
}
