using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class UserPlanRepository : Repository<UserPlan>, IUserPlanRepository
    {
        public UserPlanRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<UserPlan>> GetByIdWithInfoAsync(int userPlanId)
        {
            return await FindByCondition(p => p.UserId == userPlanId, trackChanges: false)
                            .Include(p => p.PlanInfo)
                            .ToListAsync();
        }

        public async Task<IEnumerable<UserPlan>> GetByUserIdAsync(int userId)
        {
            return await FindByCondition(up => up.UserId == userId, trackChanges: false)
                            .Include(up => up.PlanInfo)
                            .ToListAsync();
        }
    }

}
