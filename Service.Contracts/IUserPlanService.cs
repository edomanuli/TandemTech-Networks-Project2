using DTOs;

namespace Service.Contracts
{
    public interface IUserPlanService
    {
        Task<IEnumerable<PlanInfoDto>> GetPlanOptions();
        Task<IEnumerable<UserPlanDto>> GetUserPlans(int userPlanId);
        Task<UserPlanDto> EnrollUserInPlan(int userId, UserPlanCreateDto userPlanEnrollmentDto);
        Task CancleUserPlan(int userPlanId);
    }
}
