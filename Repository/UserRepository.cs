using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Contracts;

namespace Repository
{
    internal class UserRepository : IUserRepository
    {
        public void CreateStudent(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
