using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context) { }
    }
}
