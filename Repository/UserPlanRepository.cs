using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Contracts;

namespace Repository
{
    internal class UserPlanRepository : IUserPlanRepository
    {
        public void CreateUserPlanAsync(UserPlan userPlan)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserPlanAsync(UserPlan userPlan)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserPlan>> GetAllUserPlansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserPlan> GetUserPlanAsync(Guid userPlanId)
        {
            throw new NotImplementedException();
        }
    }
}
