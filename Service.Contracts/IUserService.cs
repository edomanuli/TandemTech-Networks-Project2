using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistration);
        Task<bool> AuthenticateUser(UserLoginDto userLogin);
        Task<string> CreateToken();

        // Other user management methods can be added here, such as:
        // Task<UserDto> GetUserByIdAsync(string userId);
        // Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdate);
        // Task<IdentityResult> DeleteUserAsync(string userId);
    }
}
