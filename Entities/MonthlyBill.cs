using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MonthlyBill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BillingDate { get; set; }
        public decimal Total { get; set; }
        public bool IsPaid { get; set; } = false;
        
        public User? User { get; set; }
        public ICollection<PlanBill>? PlanBills { get; set; }
    }
}
