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
    public class UserPlanRepository : RepositoryBase<UserPlan>, IUserPlanRepository
    {
        public UserPlanRepository(RepositoryContext context) : base(context) { }

        public void CreateUserPlan(UserPlan userPlan) => Create(userPlan);

        public void DeleteUserPlan(UserPlan userPlan) => Delete(userPlan);

        public async Task<IEnumerable<UserPlan>> GetAllUserPlansAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                         .Include(up => up.User)
                         .Include(up => up.PlanInfo)
                         .ToListAsync();
        }

        public async Task<UserPlan?> GetUserPlanAsync(int userPlanId, bool trackChanges)
        {
            return await FindByCondition(up => up.Id == userPlanId, trackChanges)
                         .Include(up => up.User)
                         .Include(up => up.PlanInfo)
                         .FirstOrDefaultAsync();
        }
    }

}
