using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Service.Contracts
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistration);
        Task<IdentityResult> AuthenticateAsync(UserLoginDto userLogin);
        bool ValidateToken(string token);
    }
}
