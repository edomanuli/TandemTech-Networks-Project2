using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Service.Contracts
{
    public interface IPhonePlanService
    {
        Task<PhonePlanDto> GetPhonePlanAsync(int phonePlanId, bool trackChanges);
        Task<IEnumerable<PhonePlanDto>> GetAllPhonePlansAsync();
    }
}
