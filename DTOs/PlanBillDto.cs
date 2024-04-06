using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record PlanBillDto
    {
        public int Id { get; set; }
        public int MonthlyBillId { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Amount { get; set; }
    }
}
