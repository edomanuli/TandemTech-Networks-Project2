using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contracts
{
    public interface IPlanInfoRepository
    {
        Task<PlanInfo?> GetPlanInfoAsync(int phonePlanId, bool trackChanges);
        IEnumerable<PlanInfo> GetAllPlansAsync(bool trackChanges);
        void DeletePhonePlan(PlanInfo phonePlan);
    }
}
