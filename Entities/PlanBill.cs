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
        public int BillId { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Amount { get; set; }

        public MonthlyBill? MonthlyBill { get; set; }
    }
}
