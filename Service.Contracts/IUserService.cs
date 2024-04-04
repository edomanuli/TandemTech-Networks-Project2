using DTOs;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
