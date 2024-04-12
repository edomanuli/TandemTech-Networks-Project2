using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlanInfoId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public User? User { get; set; }
        public PlanInfo? PlanInfo { get; set; }
        public ICollection<AssignedNumber>? AssignedNumbers { get; set; } = new List<AssignedNumber>();
    }
}
