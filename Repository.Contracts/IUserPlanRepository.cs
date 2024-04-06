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
        Task<IEnumerable<UserPlan>> GetAllUserPlansAsync();
        Task<UserPlan?> GetUserPlanAsync(int userPlanId);

        void CreateUserPlan(UserPlan userPlan);
        void DeleteUserPlan(UserPlan userPlan);
    }
}
