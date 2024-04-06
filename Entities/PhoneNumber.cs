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
        public int Id { get; set; }
        public string? Number { get; set; }
        public bool IsPorted { get; set; }

        public ICollection<AssignedNumber>? AssignedNumbers { get; set; }
    }
}
