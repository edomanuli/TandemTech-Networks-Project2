using DTOs;

namespace Service.Contracts
{
    public interface IUserPlanService
    {
        Task<IEnumerable<UserPlanDto>> GetAllUserPlansAsync(bool trackChanges);
        Task<UserPlanDto> GetUserPlanAsync(int userPlanId);
        Task<UserPlanDto> CreateUserPlanAsync(UserPlanCreateDto userPlanCreateDto);
        Task DeleteUserPlanAsync(int userPlanId, bool trackChanges);
    }
}
