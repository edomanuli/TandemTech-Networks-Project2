using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Route("api/user/devices")]
    [Authorize]
    public class DevicesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public DevicesController(IServiceManager serviceManager)
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

        // GET: api/user/devices
        [HttpGet]
        public async Task<IActionResult> GetUserDevices()
        {
            int userId = GetUserId(); // Get the user ID from the claims
            var devices = await _service.Device.GetDevicesByUserIdAsync(userId);
            return Ok(devices); // Return the list of devices
        }

        // DELETE: api/user/devices/5
        [HttpDelete("{deviceId}")]
        public async Task<IActionResult> DeleteUserDevice(int deviceId)
        {
            int userId = GetUserId();

            // Get the device
            var device = await _service.Device.GetDeviceByIdAsync(deviceId);
            if (device == null)
            {
                return NotFound("Device not found.");
            }

            // TOD: Check if user owns device

            await _service.Device.DeleteDeviceAsync(deviceId);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] DeviceCreateDto deviceDto)
        {
            int userId = GetUserId();
            var device = await _service.Device.AddDeviceAsync(userId, deviceDto);
            return Ok(device);
        }
    }
}
