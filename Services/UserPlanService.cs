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
        private readonly IMapper _mapper;

        public UserPlanService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserPlanDto>> GetAllUserPlansAsync(bool trackChanges)
        {
            var userPlans = await _repositoryManager.UserPlan.GetAllUserPlansAsync(trackChanges);
            return _mapper.Map<IEnumerable<UserPlanDto>>(userPlans);
        }

        public async Task<UserPlanDto> GetUserPlanAsync(int userPlanId)
        {
            var userPlan = await _repositoryManager.UserPlan.GetUserPlanAsync(userPlanId, trackChanges: false);
            return _mapper.Map<UserPlanDto>(userPlan);
        }

        public async Task<UserPlanDto> CreateUserPlanAsync(UserPlanCreateDto userPlanCreateDto)
        {
            var userPlan = _mapper.Map<UserPlan>(userPlanCreateDto);
            _repositoryManager.UserPlan.CreateUserPlan(userPlan);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<UserPlanDto>(userPlan);
        }

        public async Task DeleteUserPlanAsync(int userPlanId, bool trackChanges)
        {
            var userPlan = await _repositoryManager.UserPlan.GetUserPlanAsync(userPlanId, trackChanges);
            if (userPlan == null)
            {
                throw new NotFoundException($"UserPlan with ID {userPlanId} not found.");
            }

            _repositoryManager.UserPlan.DeleteUserPlan(userPlan);
            await _repositoryManager.SaveAsync();
        }
    }


}
