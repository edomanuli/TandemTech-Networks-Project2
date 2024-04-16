using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DeviceInfoRepository : Repository<DeviceInfo>, IDeviceInfoRepository
    {
        public DeviceInfoRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {
        }

    }
}
