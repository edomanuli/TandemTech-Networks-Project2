using AutoMapper;
using Repository.Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {   
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPlanInfoService> _PlanInfoService;
       
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _PlanInfoService = new Lazy<IPlanInfoService> (() => new PlanInfoService(repositoryManager, mapper));
        }

        public IUserService User => _userService.Value;
        public IPlanInfoService PlanInfo => _PlanInfoService.Value;
    }
}
