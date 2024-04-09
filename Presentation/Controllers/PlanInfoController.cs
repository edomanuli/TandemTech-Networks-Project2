using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    [Route("api/planinfo")]
    [ApiController]
    public class PlanInfoController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PlanInfoController(IServiceManager serviceManager) => _service = serviceManager;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllPlanInfo()
        {
            var plans = await _service.PlanInfo.GetAllPlanInfoAsync();
            return Ok(plans);
        }

        [HttpGet("{id:int}", Name = "planInfoId")]
        public async Task<IActionResult> GetPlanInfo(int id)
        {
            var planInfo = await _service.PlanInfo.GetPlanInfoAsync(id, trackChanges: false);

            if (planInfo == null)
            {
                return NotFound();
            }
            return Ok(planInfo);
        }
    }
}
