using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetDevicesByUserIdAsync(int userId);
        Task<Device> GetDeviceByIdAsync(int deviceId);

    }
}
