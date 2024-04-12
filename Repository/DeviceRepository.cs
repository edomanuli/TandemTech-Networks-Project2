using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<Device>> GetDevicesByUserIdAsync(int userId)
        {
            return await RepositoryContext.Devices
                .Include(device => device.AssignedNumber)
                    .ThenInclude(assignedNumber => assignedNumber.PhoneNumber)
                .Include(device => device.DeviceInfo)
                .Where(device => device.AssignedNumber.UserPlan.UserId == userId)
                .ToListAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(int deviceId)
        {
            return await RepositoryContext.Devices
                .Include(d => d.AssignedNumber)
                    .ThenInclude(an => an.UserPlan)
                .Include(d => d.DeviceInfo)
                .SingleOrDefaultAsync(d => d.Id == deviceId);
        }
    }
}
