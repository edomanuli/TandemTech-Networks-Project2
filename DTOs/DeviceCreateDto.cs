using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record DeviceCreateDto
    {
        public string Name { get; set; }
        public string Serial { get; set; }
        public int DeviceInfoId { get; set; }
        public int UserPlanId { get; set; }
    }
}
