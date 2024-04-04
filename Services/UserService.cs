using DTOs;
using Microsoft.VisualBasic;
using Service.Contracts;
using Repository.Contracts;

namespace Service
{
    public class UserService : IUserService
    {   
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<UserDto> GetUserAsync(int userId, bool trackChanges)
        {
            var userEntity = await _repositoryManager.User.GetUserAsync(userId, trackChanges);

            // Manual mapping for now, will use automapper latter
            var userDto = new UserDto
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email
            };

            return userDto;
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

    }
}
