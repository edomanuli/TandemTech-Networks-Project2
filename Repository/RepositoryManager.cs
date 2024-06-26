﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IPlanInfoRepository> _planInfoRepository;
        private readonly Lazy<IUserPlanRepository> _userPlanRepository;
        private readonly Lazy<IAssignedNumberRepository> _assignedNumberRepository;
        private readonly Lazy<IPhoneNumberRepository> _phoneNumberRepository;
        private readonly Lazy<IMonthlyBillRepository> _monthlyBillRepository;
        private readonly Lazy<IDeviceRepository> _deviceRepository;
        private readonly Lazy<IDeviceInfoRepository> _deviceInfoRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext));
            _planInfoRepository = new Lazy<IPlanInfoRepository>(() => new PlanInfoRepository(_repositoryContext));
            _userPlanRepository = new Lazy<IUserPlanRepository>(() => new UserPlanRepository(_repositoryContext));
            _assignedNumberRepository = new Lazy<IAssignedNumberRepository>(() => new AssignedNumberRepository(_repositoryContext));
            _phoneNumberRepository = new Lazy<IPhoneNumberRepository>(() => new PhoneNumberRepository(_repositoryContext));
            _monthlyBillRepository = new Lazy<IMonthlyBillRepository>(() => new MonthlyBillRepository(_repositoryContext));
            _deviceRepository = new Lazy<IDeviceRepository>(() => new DeviceRepository(_repositoryContext));
            _deviceInfoRepository = new Lazy<IDeviceInfoRepository>(() => new DeviceInfoRepository(_repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IPlanInfoRepository PlanInfo => _planInfoRepository.Value;
        public IUserPlanRepository UserPlan => _userPlanRepository.Value;
        public IAssignedNumberRepository AssignedNumber => _assignedNumberRepository.Value;
        public IPhoneNumberRepository PhoneNumber => _phoneNumberRepository.Value;
        public IMonthlyBillRepository MonthlyBill => _monthlyBillRepository.Value;
        public IDeviceRepository Device => _deviceRepository.Value;
        public IDeviceInfoRepository DeviceInfo => _deviceInfoRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }

}
