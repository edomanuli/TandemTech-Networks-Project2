using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlanPhoneNumber
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(UserPlanId))]
        public Guid UserPlanId { get; set; }
        public UserPlan? UserPlan { get; set; }

        [ForeignKey(nameof(PhoneNumberId))]
        public Guid PhoneNumberId { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
    }
}
