using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IPhonePlanRepository> _phonePlanRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_repositoryContext));
            _phonePlanRepository = new Lazy<IPhonePlanRepository>(() => new PhonePlanRepository(_repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IPhonePlanRepository PhonePlan => _phonePlanRepository.Value;
    }
}
