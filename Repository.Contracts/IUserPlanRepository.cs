using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contracts
{
    public interface IUserPlanRepository
    {
        Task<IEnumerable<UserPlan>> GetAllUserPlansAsync(bool trackChanges);
        Task<UserPlan?> GetUserPlanAsync(int userPlanId, bool trackChanges);

        void CreateUserPlan(UserPlan userPlan);
        void DeleteUserPlan(UserPlan userPlan);
    }
}
