using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlanInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DeviceLimit { get; set; }
        public decimal Price { get; set; }
        public int DataLimit { get; set; }
        public string? Description { get; set; }

        public ICollection<UserPlan>? UserPlans { get; set; }
    }
}
