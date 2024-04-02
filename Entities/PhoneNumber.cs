using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string? Number { get; set; }
    }
}
