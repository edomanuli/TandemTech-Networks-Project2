using DTOs;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int userId, bool trackChanges);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
