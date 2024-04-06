using System;
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

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext));
            _planInfoRepository = new Lazy<IPlanInfoRepository>(() => new PlanInfoRepository(_repositoryContext));
            _userPlanRepository = new Lazy<IUserPlanRepository>(() => new UserPlanRepository(_repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IPlanInfoRepository PlanInfo => _planInfoRepository.Value;
        public IUserPlanRepository UserPlan => _userPlanRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
