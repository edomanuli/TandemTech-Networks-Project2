using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlanBill
    {
        public int Id { get; set; }
        public int MonthlyBillId { get; set; }
        public int UserPlanId { get; set; }
        public decimal Amount { get; set; }

        public MonthlyBill? MonthlyBill { get; set; }
        public UserPlan? UserPlan { get; set; }
    }
}
