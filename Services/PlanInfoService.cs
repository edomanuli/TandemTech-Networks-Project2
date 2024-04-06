using DTOs;
using Repository.Contracts;
using Service.Contracts;
using AutoMapper;
using Entities;
using Entities.Exceptions;

namespace Service
{
    public class PlanInfoService : IPlanInfoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PlanInfoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PlanInfoDto> GetPlanInfoAsync(int phonePlanId, bool trackChanges)
        {
            var planInfoEntity = await _repositoryManager.PlanInfo.GetPlanInfoAsync(phonePlanId, trackChanges);

            if ( planInfoEntity == null)
            {
                throw new NotFoundException($"Plan with ID {phonePlanId} not found.");
            }

            return _mapper.Map<PlanInfoDto>(planInfoEntity);

        }

        public async Task<IEnumerable<PlanInfoDto>> GetAllPlanInfoAsync()
        {
            var planInfoEntities = await _repositoryManager.PlanInfo.GetAllPlansAsync();
            return _mapper.Map<IEnumerable<PlanInfoDto>>(planInfoEntities);
        }
    }
}
