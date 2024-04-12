using Entities;

namespace Repository.Contracts
{
    public interface IUserPlanRepository : IRepository<UserPlan>
    {
        Task<IEnumerable<UserPlan>> GetByUserIdAsync(int userId);
        Task<UserPlan> GetByIdWithInfoAsync(int userPlanId);
    }
}
