using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTOs;
using Entities;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts;

namespace Service
{
    public class UserPlanService : IUserPlanService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserPlanService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserPlanDto>> GetAllUserPlansAsync(bool trackChanges)
        {
            var userPlans = await _repositoryManager.UserPlan.GetAllAsync();
            return _mapper.Map<IEnumerable<UserPlanDto>>(userPlans);
        }

        public async Task<UserPlanDto> GetUserPlanAsync(int userPlanId)
        {
            var userPlan = await _repositoryManager.UserPlan.GetByIdAsync(userPlanId);
            return _mapper.Map<UserPlanDto>(userPlan);
        }

        public async Task<UserPlanDto> CreateUserPlanAsync(UserPlanCreateDto userPlanCreateDto)
        {
            var userPlan = _mapper.Map<UserPlan>(userPlanCreateDto);
            _repositoryManager.UserPlan.Create(userPlan);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<UserPlanDto>(userPlan);
        }

        public async Task DeleteUserPlanAsync(int userPlanId, bool trackChanges)
        {
            var userPlan = await _repositoryManager.UserPlan.GetByIdAsync(userPlanId);
            if (userPlan == null)
            {
                throw new UserPlanNotFoundException(userPlanId);
            }

            _repositoryManager.UserPlan.Delete(userPlan);
            await _repositoryManager.SaveAsync();
        }
    }


}
