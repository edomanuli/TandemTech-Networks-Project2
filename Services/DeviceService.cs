using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository.Contracts;
using Service.Contracts;
using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using AutoMapper.Internal.Mappers;

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

        public async Task DeleteDeviceAsync(int deviceId)
        {
            var device = await _repositoryManager.Device.GetByIdAsync(deviceId);
            if (device == null)
            {
                throw new KeyNotFoundException("Device not found.");
            }

            var number = await _repositoryManager.AssignedNumber.GetByIdAsync(device.AssignedNumberId);
            if (number != null)
            {
                _repositoryManager.AssignedNumber.Delete(number);
            }

            _repositoryManager.Device.Delete(device);
            await _repositoryManager.SaveAsync();
        }

        public async Task<DeviceDto> GetDeviceByIdAsync(int deviceId)
        {
            var device = await _repositoryManager.Device.GetByIdAsync(deviceId);
            if (device == null)
            {
                throw new KeyNotFoundException("Device not found.");
            }
            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<DeviceDto> AddDeviceAsync(int userId, DeviceCreateDto deviceDto)
        {
            // Verify that the UserPlan belongs to the User
            var userPlan = await _repositoryManager.UserPlan.GetByIdWithInfoAsync(deviceDto.UserPlanId);
            if (userPlan == null || userPlan.UserId != userId)
            {
                throw new ArgumentException("Invalid user plan ID or user plan does not belong to the user.");
            }

            //TODO: Check if device info exists


            // Check device limit
            if (userPlan.AssignedNumbers.Count >= userPlan.PlanInfo.DeviceLimit)
            {
                throw new InvalidOperationException("Device limit exceeded for this plan.");
            }

            // Get an unassigned number
            var phoneNumber = await _repositoryManager.PhoneNumber.GetUnassignedPhoneNumberAsync();
            if (phoneNumber == null)
            {
                throw new InvalidOperationException("No available phone numbers.");
            }

            // Create the device
            var device = new Device
            {
                Name = deviceDto.Name,
                Serial = deviceDto.Serial,
                DeviceInfoId = deviceDto.DeviceInfoId,
                AssignedNumber = new AssignedNumber
                {
                    UserPlanId = userPlan.Id,
                    PhoneNumberId = phoneNumber.Id
                }
            };

            _repositoryManager.Device.Create(device);
            await _repositoryManager.SaveAsync(); 

            return _mapper.Map<DeviceDto>(device);
        }
    }
}
