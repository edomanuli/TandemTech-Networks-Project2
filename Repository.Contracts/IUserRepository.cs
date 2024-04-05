using Entities;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId, bool trackChanges);

        Task<IEnumerable<User>> GetAllUsersAsync();

        public void CreateUser(User user);
        public void DeleteUser(User user);
    }
}
