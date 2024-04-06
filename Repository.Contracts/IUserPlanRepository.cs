using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contracts
{
    public interface IUserPlanRepository : IRepository<UserPlan>
    {
        Task<IEnumerable<UserPlan>> GetByUserIdAsync(int userId);
    }
}
