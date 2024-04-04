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
       
        public ServiceManager()
        {
            _userService = new Lazy<IUserService> (() => new UserService());
        }

        public IUserService User => _userService.Value;
    }
}
