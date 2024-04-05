using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
    [Route("api/phoneplan")]
    [ApiController]
    public class PhonePlanController : ControllerBase
    {
        private readonly IServiceManager _service;

        public PhonePlanController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpGet]
        //public IActionResult GetPhonePlans()
        //{
        //    var phonePlans = _service.PhonePlan.GetAllPhonePlans(trackChanges: false);
        //    return Ok(phonePlans);
        //}
        

        [HttpGet("{id:int}", Name = "PhonePlanById")]
        public async Task<IActionResult> GetPhonePlan([FromRoute] int id)
        {
            var phonePlan = await _service.PhonePlan.GetPhonePlanAsync(id, trackChanges: false);

            if (phonePlan == null)
            {
                return NotFound();
            }
            return Ok(phonePlan);
        }
    }
}
