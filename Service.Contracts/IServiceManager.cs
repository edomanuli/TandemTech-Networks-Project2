using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IUserService User { get; }
        IInfoService Info { get; }
        IUserPlanService UserPlan { get; }
        IAssignedNumberService AssignedNumber { get; }
        IPhoneNumberService PhoneNumber { get; }

        IMonthlyBillService MonthlyBill { get; }

        IDeviceService Device { get; }
    }

}
