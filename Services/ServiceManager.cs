using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository.Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {   
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPhonePlanService> _phonePlanService;
       
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _phonePlanService = new Lazy<IPhonePlanService> (() => new PhonePlanService(repositoryManager));
        }

        public IUserService User => _userService.Value;
        public IPhonePlanService PhonePlan => _phonePlanService.Value;
    }
}
