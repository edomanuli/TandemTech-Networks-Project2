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
    public class PlanInfoRepository : RepositoryBase<PlanInfo>, IPlanInfoRepository
    {
        public PlanInfoRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {
        }

        public void DeletePhonePlan(PlanInfo phonePlan)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanInfo> GetAllPlansAsync(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(pp => pp.Name).ToList();
        }

        public async Task<PlanInfo?> GetPlanInfoAsync(int phonePlanId, bool trackChanges)
        {
            if (trackChanges)
            {
                return await RepositoryContext.PlanInfo.FindAsync(phonePlanId);
            }
            else
            {
                return await RepositoryContext.PlanInfo
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == phonePlanId);
            }
        }

        public Task<PlanInfo?> GetPlanAsync(int phonePlanId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
