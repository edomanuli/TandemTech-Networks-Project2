using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateUser(User user) => Create(user);

        public void DeleteUser(User user) => Delete(user);

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await RepositoryContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetUserAsync(int userId, bool trackChanges)
        {
            var query = FindByCondition(u => u.Id.Equals(userId), trackChanges);
            var user = await query.SingleOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
        {
            var query = FindAll(trackChanges).OrderBy(s => s.LastName);
            return await query.ToListAsync();
        }
    }
}
