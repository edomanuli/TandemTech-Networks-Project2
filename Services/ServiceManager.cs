using AutoMapper;
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

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _planInfoService = new Lazy<IPlanInfoService>(() => new PlanInfoService(repositoryManager, mapper));
            _userPlanService = new Lazy<IUserPlanService>(() => new UserPlanService(repositoryManager, mapper));
            _assignedNumberService = new Lazy<IAssignedNumberService>(() => new AssignedNumberService(repositoryManager, mapper));
            _phoneNumberService = new Lazy<IPhoneNumberService>(() => new PhoneNumberService(repositoryManager, mapper));
        }

        public IUserService User => _userService.Value;
        public IPlanInfoService PlanInfo => _planInfoService.Value;
        public IUserPlanService UserPlan => _userPlanService.Value;
        public IAssignedNumberService AssignedNumber => _assignedNumberService.Value;
        public IPhoneNumberService PhoneNumber => _phoneNumberService.Value;
    }

}
