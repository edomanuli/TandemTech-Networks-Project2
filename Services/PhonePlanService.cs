using DTOs;
using Repository.Contracts;
using Service.Contracts;

namespace Service
{
    public class PhonePlanService : IPhonePlanService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PhonePlanService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PhonePlanDto> GetPhonePlanAsync(int phonePlanId, bool trackChanges)
        {
            var phonePlanEntity = await _repositoryManager.PlanInfo.GetPlanInfoAsync(phonePlanId, trackChanges);

            // Manual mapping for now, will use automapper later
            var phonePlanDto = new PhonePlanDto
            {
                Id = phonePlanEntity.Id,
                Name = phonePlanEntity.Name,
                Description = phonePlanEntity.Description,
                Price = phonePlanEntity.Price,
                DeviceLimit = phonePlanEntity.DeviceLimit,
                DataLimit = phonePlanEntity.DataLimit
            };

            return phonePlanDto;
        }

        public Task<IEnumerable<PhonePlanDto>> GetAllPhonePlansAsync()
        {
            throw new NotImplementedException();
        }
    }
}
