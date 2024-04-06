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
    public class AssignedNumberRepository : RepositoryBase<AssignedNumber>, IAssignedNumberRepository
    {
        public AssignedNumberRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<AssignedNumber>> GetAllAsync() =>
            await FindAll(trackChanges: false).ToListAsync();

        public async Task<AssignedNumber?> GetByIdAsync(int id) =>
            await FindByCondition(an => an.Id == id, trackChanges: false)
                .Include(an => an.PhoneNumber)
                .Include(an => an.UserPlan)
                .Include(an => an.Device)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<AssignedNumber>> GetByPlanIdAsync(int planId)
        {
            return await FindByCondition(an => an.UserPlanId == planId, trackChanges: false)
                .Include(an => an.UserPlan)
                .Include(an => an.PhoneNumber)
                .ToListAsync();
        }
    }


}
