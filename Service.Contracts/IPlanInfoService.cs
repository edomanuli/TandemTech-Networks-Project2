using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Service.Contracts
{
    public interface IPlanInfoService
    {
        Task<PlanInfoDto> GetPlanInfoAsync(int phonePlanId, bool trackChanges);
        Task<IEnumerable<PlanInfoDto>> GetAllPlanInfoAsync();
        //object GetAllPlanInfoAsync();
    }
}
