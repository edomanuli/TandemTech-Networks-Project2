using DTOs;
using Microsoft.VisualBasic;
using Service.Contracts;

namespace Service
{
    public class UserService : IUserService
    {   
        public async Task<UserDto> GetUserAsync(int userId)
        {
            UserDto dto = new UserDto();
            dto.FirstName = "Chris";
            dto.LastName = "Leipold";
            dto.Email = "Chris@gmail.com";
            return dto;
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
