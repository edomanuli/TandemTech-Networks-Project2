using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    [Route("api")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IServiceManager _service;

        public InfoController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet("planinfo")]
        public async Task<IActionResult> GetAllPlanInfo()
        {
            var plans = await _service.Info.GetAllPlanInfoAsync();
            return Ok(plans);
        }

        [HttpGet("planinfo/{id:int}", Name = "planInfoId")]
        public async Task<IActionResult> GetPlanInfo(int id)
        {
            var planInfo = await _service.Info.GetPlanInfoAsync(id, trackChanges: false);

            if (planInfo == null)
            {
                return NotFound();
            }
            return Ok(planInfo);
        }


        [HttpGet("deviceinfo")]
        public async Task<IActionResult> GetAllDeviceInfo()
        {
            var deviceInfos = await _service.Info.GetAllDeviceInfoAsync();
            return Ok(deviceInfos);
        }

    }
}
