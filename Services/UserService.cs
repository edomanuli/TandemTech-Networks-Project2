using DTOs;
using Microsoft.VisualBasic;
using Service.Contracts;
using Repository.Contracts;
using AutoMapper;
using Entities;
using Entities.Exceptions;

namespace Service
{
    public class UserService : IUserService
    {   
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var userEntity = _mapper.Map<User>(userCreateDto);
            _repositoryManager.User.Create(userEntity);
            await _repositoryManager.SaveAsync();  // Assuming SaveAsync is implemented in IRepositoryManager

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userEntity = await _repositoryManager.User.GetByIdAsync(userId);
            if (userEntity == null)
            {
                throw new NotFoundException($"User with ID {userId} not found.");
            }

            _repositoryManager.User.Delete(userEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task<UserDto> GetUserAsync(int userId, bool trackChanges)
        {
            var userEntity = await _repositoryManager.User.GetByIdAsync(userId);
            if (userEntity == null)
            {
                throw new NotFoundException($"User with ID {userId} not found.");
            }

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var userEntities = await _repositoryManager.User.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        }

    }
}
