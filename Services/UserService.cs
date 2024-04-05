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
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var userEntity = _mapper.Map<User>(userCreateDto);
            _repositoryManager.User.CreateUser(userEntity);
            await _repositoryManager.SaveAsync();  // Assuming SaveAsync is implemented in IRepositoryManager

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userEntity = await _repositoryManager.User.GetUserAsync(userId, trackChanges: false);
            if (userEntity == null)
            {
                throw new NotFoundException($"User with ID {userId} not found.");
            }

            _repositoryManager.User.DeleteUser(userEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task<UserDto> GetUserAsync(int userId, bool trackChanges)
        {
            var userEntity = await _repositoryManager.User.GetUserAsync(userId, trackChanges);
            if (userEntity == null)
            {
                throw new NotFoundException($"User with ID {userId} not found.");
            }

            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var userEntities = await _repositoryManager.User.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        }

    }
}
