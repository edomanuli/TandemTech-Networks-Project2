using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserPlanDto
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public UserDto? User { get; set; }
        public PlanInfoDto? PlanInfo { get; set; }
    }
}
