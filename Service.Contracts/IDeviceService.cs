using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Service.Contracts
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>> GetDevicesByUserIdAsync(int userId);
        Task DeleteDeviceAsync(int deviceId);
        Task<DeviceWithDetailsDto> GetDeviceByIdAsync(int deviceId);
        Task<DeviceWithDetailsDto> AddDeviceAsync(int userId, DeviceCreateDto deviceDto);
        Task<DeviceWithDetailsDto> AssignDeviceNumber(int deviceId, int assignedNumberId);
    }
}
