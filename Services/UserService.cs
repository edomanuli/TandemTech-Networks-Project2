using DTOs;
using Microsoft.VisualBasic;
using Service.Contracts;
using Repository.Contracts;
using AutoMapper;
using Entities;

namespace Service
{
    public class UserService : IUserService
    {   
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(int userId, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserAsync(userId, trackChanges);
            return _mapper.Map<UserDto>(user);
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

    }
}
