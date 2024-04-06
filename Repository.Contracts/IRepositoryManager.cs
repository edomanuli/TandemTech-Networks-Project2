using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IPlanInfoRepository PlanInfo { get; }
        IPhoneNumberRepository PhoneNumber { get; }

        IUserPlanRepository UserPlan { get; }
        IAssignedNumberRepository AssignedNumber { get; }
        
        IMonthlyBillRepository MonthlyBill { get; }

        Task SaveAsync();
    }
}
