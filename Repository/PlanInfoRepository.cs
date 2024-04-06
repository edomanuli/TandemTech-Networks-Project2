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
    public class PlanInfoRepository : Repository<PlanInfo>, IPlanInfoRepository
    {
        public PlanInfoRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {
        }

        public async Task<IEnumerable<PlanInfo>> GetAllAsync()
        {
            return await RepositoryContext.Set<PlanInfo>().ToListAsync();
        }

        public Task<PlanInfo?> GetByIdAsync(int phonePlanId)
        {
            var phonePlan = FindByCondition(p => p.Id.Equals(phonePlanId), trackChanges: false).SingleOrDefault();
            return Task.FromResult(phonePlan);
        }

        //public async Task<IEnumerable<PlanInfo>> GetAllPlansAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
