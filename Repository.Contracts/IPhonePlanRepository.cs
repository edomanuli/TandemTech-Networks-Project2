using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contracts
{
    public interface IPhonePlanRepository
    {
        Task<PhonePlan?> GetPhonePlanAsync(int phonePlanId, bool trackChanges);
        IEnumerable<PhonePlan> GetAllPhonePlansAsync(bool trackChanges);
        void DeletePhonePlan(PhonePlan phonePlan);
    }
}
