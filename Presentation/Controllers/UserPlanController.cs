using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    [Route("api/userplans")]
    [ApiController]
    public class UserPlanController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UserPlanController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserPlans()
        {
            var userPlans = await _service.UserPlan.GetAllUserPlansAsync(trackChanges: false);
            return Ok(userPlans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPlan(int id)
        {
            var userPlan = await _service.UserPlan.GetUserPlanAsync(id);
            if (userPlan == null)
            {
                return NotFound($"User plan with ID {id} not found.");
            }
            return Ok(userPlan);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserPlan([FromBody] UserPlanCreateDto userPlanCreateDto)
        {
            var createdUserPlan = await _service.UserPlan.CreateUserPlanAsync(userPlanCreateDto);
            return CreatedAtAction(nameof(GetUserPlan), new { id = createdUserPlan.Id }, createdUserPlan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPlan(int id)
        {
            await _service.UserPlan.DeleteUserPlanAsync(id, trackChanges: false);
            return NoContent();
        }

    }
}
