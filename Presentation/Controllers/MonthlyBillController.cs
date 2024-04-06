using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/bills")]
    public class MonthlyBillController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public MonthlyBillController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBillsByUserId(int userId)
        {
            var bills = await _serviceManager.MonthlyBill.GetBillsByUserIdAsync(userId);
            return Ok(bills);
        }

        [HttpPut("{billId}/markaspaid")]
        public async Task<IActionResult> MarkBillAsPaid(int billId)
        {
            await _serviceManager.MonthlyBill.MarkBillAsPaidAsync(billId);
            return NoContent();
        }
    }

}
