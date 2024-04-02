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
        public Guid Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(PhonePlanId))]
        public Guid PhonePlanId { get; set; }
        public PhonePlan? PhonePlan { get; set; }
    }
}
