using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Device
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [ForeignKey(nameof(PlanPhoneNumberId))]
        public Guid PlanPhoneNumberId { get; set; }
        public PlanPhoneNumber? PlanPhoneNumber { get; set; }
    }
}
