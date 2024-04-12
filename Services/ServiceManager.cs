using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPlanInfoService> _planInfoService;
        private readonly Lazy<IUserPlanService> _userPlanService;
        private readonly Lazy<IAssignedNumberService> _assignedNumberService;
        private readonly Lazy<IPhoneNumberService> _phoneNumberService;
        private readonly Lazy<IMonthlyBillService> _monthlyBillService;
        private readonly Lazy<IDeviceService> _deviceService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper, userManager, configuration));
            _planInfoService = new Lazy<IPlanInfoService>(() => new PlanInfoService(repositoryManager, logger, mapper));
            _userPlanService = new Lazy<IUserPlanService>(() => new UserPlanService(repositoryManager, logger, mapper));
            _assignedNumberService = new Lazy<IAssignedNumberService>(() => new AssignedNumberService(repositoryManager, logger, mapper));
            _phoneNumberService = new Lazy<IPhoneNumberService>(() => new PhoneNumberService(repositoryManager, logger, mapper));
            _monthlyBillService = new Lazy<IMonthlyBillService>(() => new MonthlyBillService(repositoryManager, logger, mapper));
            _deviceService = new Lazy<IDeviceService>(() => new DeviceService(repositoryManager, logger, mapper));
        }

        public IUserService User => _userService.Value;
        public IPlanInfoService PlanInfo => _planInfoService.Value;
        public IUserPlanService UserPlan => _userPlanService.Value;
        public IAssignedNumberService AssignedNumber => _assignedNumberService.Value;
        public IPhoneNumberService PhoneNumber => _phoneNumberService.Value;
        public IMonthlyBillService MonthlyBill => _monthlyBillService.Value;
        public IDeviceService Device => _deviceService.Value;
    }

}
