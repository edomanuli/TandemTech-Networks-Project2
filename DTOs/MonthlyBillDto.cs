using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record MonthlyBillDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Total { get; set; }
        public bool IsPaid { get; set; } = false;
        public IEnumerable<PlanBillDto> PlanBills { get; set; }
    }
}
