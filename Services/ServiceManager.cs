using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {   
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IPhonePlanService> _phonePlanService;
       
        public ServiceManager()
        {
            _userService = new Lazy<IUserService> (() => new UserService());
            _phonePlanService = new Lazy<IPhonePlanService> (() => new PhonePlanService());
        }

        public IUserService User => _userService.Value;
        public IPhonePlanService PhonePlan => _phonePlanService.Value;
    }
}
