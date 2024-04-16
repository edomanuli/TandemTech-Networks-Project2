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
        public int Id { get; set; }
        public int? AssignedNumberId { get; set; }
        public int DeviceInfoId { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }

        public AssignedNumber? AssignedNumber { get; set; }
        public DeviceInfo? DeviceInfo { get; set; }
    }
}
