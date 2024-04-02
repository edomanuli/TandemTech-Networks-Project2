using Entities;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(Guid userId);

        void CreateStudent(User user);
        void DeleteStudent(User user);
    }
}
