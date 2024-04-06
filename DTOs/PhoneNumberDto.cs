using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record PhoneNumberDto
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public bool IsPorted { get; set; }
    }
}
