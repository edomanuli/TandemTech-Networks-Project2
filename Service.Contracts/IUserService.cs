using DTOs;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int userId, bool trackChanges);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        Task<UserDto> CreateUserAsync(UserCreateDto createUserDto);
        Task DeleteUserAsync(int userId);

    }
}
