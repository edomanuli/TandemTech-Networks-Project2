using Entities;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid userId);

        void CreateUser(User user);
        void DeleteUser(User user);
    }
}
