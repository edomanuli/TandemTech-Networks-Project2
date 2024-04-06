using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/number")]
    [ApiController]
    public class AssignedNumbersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AssignedNumbersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignedNumberDto>>> GetAllAssignedNumbers()
        {
            var assignedNumbers = await _service.AssignedNumber.GetAllAsync();
            return Ok(assignedNumbers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assignedNumber = await _service.AssignedNumber.GetByIdAsync(id);
            if (assignedNumber == null)
                return NotFound();

            return Ok(assignedNumber);
        }

        [HttpGet("plan/{planId}")]
        public async Task<ActionResult<IEnumerable<AssignedNumberDto>>> GetByPlanId(int planId)
        {
            try
            {
                var assignedNumbers = await _service.AssignedNumber.GetByUserPlanIdAsync(planId);
                return Ok(assignedNumbers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
