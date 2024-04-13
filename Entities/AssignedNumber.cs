using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AssignedNumber
    {
        public int Id { get; set; }
        public int PhoneNumberId { get; set; }
        public int UserPlanId { get; set; }

        public PhoneNumber? PhoneNumber { get; set; }
        public UserPlan? UserPlan { get; set; }
    }
}
