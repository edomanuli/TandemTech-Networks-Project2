using Entities;

namespace Repository.Contracts
{
    public interface IUserPlanRepository : IRepository<UserPlan>
    {
        Task<IEnumerable<UserPlan>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserPlan>> GetByIdWithInfoAsync(int userPlanId);
    }
}
