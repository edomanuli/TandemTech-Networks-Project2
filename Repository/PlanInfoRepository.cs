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

        public async Task<IEnumerable<PlanInfo>> GetAllPlansAsync()
        {
            return await RepositoryContext.Set<PlanInfo>().ToListAsync();
        }

        public Task<PlanInfo?> GetPlanInfoAsync(int phonePlanId, bool trackChanges)
        {
            var phonePlan = FindByCondition(p => p.Id.Equals(phonePlanId), trackChanges).SingleOrDefault();
            return Task.FromResult(phonePlan);
        }

        public void DeletePlanInfoAsync(PlanInfo phonePlan)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<PlanInfo>> GetAllPlansAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
