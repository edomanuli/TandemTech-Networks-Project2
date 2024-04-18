using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record AssignedNumberDto
    {
        public int Id { get; set; }
        public int PhoneNumberId { get; set; }
        public int UserPlanId { get; set; }
        public PhoneNumberDto? PhoneNumber { get; set; }
        //public DeviceDto? Device { get; set; }
        public UserPlanDto? UserPlan { get; set; }
    }
}
