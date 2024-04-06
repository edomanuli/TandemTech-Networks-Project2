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
    public class PhoneNumberRepository : RepositoryBase<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<PhoneNumber>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<PhoneNumber?> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(phone => phone.Id == id, trackChanges).SingleOrDefaultAsync();
    }
}
