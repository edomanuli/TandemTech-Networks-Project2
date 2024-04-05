using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PhonePlanRepository : RepositoryBase<PhonePlan>, IPhonePlanRepository
    {
        public PhonePlanRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {
        }

        public void DeletePhonePlan(PhonePlan phonePlan)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhonePlan> GetAllPhonePlansAsync(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(pp => pp.Name).ToList();
        }

        public async Task<PhonePlan?> GetPhonePlanAsync(int phonePlanId, bool trackChanges)
        {
            if (trackChanges)
            {
                return await RepositoryContext.PhonePlans.FindAsync(phonePlanId);
            }
            else
            {
                return await RepositoryContext.PhonePlans
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == phonePlanId);
            }
        }
    }
}
