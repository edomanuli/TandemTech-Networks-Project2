using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AssignedNumberRepository : Repository<AssignedNumber>, IAssignedNumberRepository
    {
        public AssignedNumberRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<AssignedNumber>> GetAssignedNumbersByUserIdAsync(int userId)
        {
            return await FindByCondition(an => an.UserPlan.UserId == userId, trackChanges: false)
                .Include(an => an.PhoneNumber)
                .Include(an => an.Device)
                .ToListAsync();
        }

        public async Task<IEnumerable<AssignedNumber>> GetByUserPlanIdAsync(int planId)
        {
            return await FindByCondition(an => an.UserPlanId == planId, trackChanges: false)
                .Include(an => an.PhoneNumber)
                .Include(an => an.Device)
                .ToListAsync();
        }

        public async Task<AssignedNumber> GetAssignedNumberByIdAsync(int id)
        {
            return await FindByCondition(an => an.Id == id, trackChanges: false)
                .Include(an => an.Device)
                .Include(an => an.PhoneNumber)
                .SingleOrDefaultAsync();
        }

    }
}
