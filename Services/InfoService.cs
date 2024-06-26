﻿using DTOs;
using Repository.Contracts;
using Service.Contracts;
using AutoMapper;
using Entities;
using Entities.Exceptions;

namespace Service
{
    public class InfoService : IInfoService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public InfoService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PlanInfoDto> GetPlanInfoAsync(int phonePlanId, bool trackChanges)
        {
            var planInfoEntity = await _repositoryManager.PlanInfo.GetByIdAsync(phonePlanId);

            if ( planInfoEntity == null)
            {
                throw new PlanInfoNotFoundException(phonePlanId);
            }

            return _mapper.Map<PlanInfoDto>(planInfoEntity);

        }

        public async Task<IEnumerable<PlanInfoDto>> GetAllPlanInfoAsync()
        {
            var planInfoEntities = await _repositoryManager.PlanInfo.GetAllAsync();
            return _mapper.Map<IEnumerable<PlanInfoDto>>(planInfoEntities);
        }

        public async Task<IEnumerable<DeviceInfoDto>> GetAllDeviceInfoAsync()
        {
            var deviceInfoEntities = await _repositoryManager.DeviceInfo.GetAllAsync();
            return _mapper.Map<IEnumerable<DeviceInfoDto>>(deviceInfoEntities);
        }
    }
}
