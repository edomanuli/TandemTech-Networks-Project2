﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository.Contracts;
using Service.Contracts;
using DTOs;

namespace Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DeviceService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeviceDto>> GetDevicesByUserIdAsync(int userId)
        {
            var devices = await _repositoryManager.Device.GetDevicesByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<DeviceDto>>(devices);
        }

        // Implement other methods as needed
    }
}
