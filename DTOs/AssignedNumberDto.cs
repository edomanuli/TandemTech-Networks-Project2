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

        public PhoneNumberDto? Number { get; set; }
    }

    public record AssignedNumberCreateDto
    {
        public int Id { get; set; }
        public int PhoneNumberId { get; set; }
        public int UserPlanId { get; set; }
    }

    public record AssignedNumberUpdateDto
    {
        public int Id { get; set; }
        public int PhoneNumberId { get; set; }
        public int UserPlanId { get; set; }
    }
}
