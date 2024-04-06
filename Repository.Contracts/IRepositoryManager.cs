using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IPlanInfoRepository PlanInfo { get; }

        Task SaveAsync();
    }
}
