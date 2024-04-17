using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record DeviceDto
    {
        public int Id { get; set; }
        public int AssignedNumberId { get; set; }
        public int DeviceInfoId { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }

        // public AssignedNumberDto AssignedNumber { get; set; }
        // public DeviceInfoDto DeviceInfo { get; set; }
    }

    public record DeviceWithDetailsDto
    {
        public int Id { get; set; }
        public int AssignedNumberId { get; set; }
        public int DeviceInfoId { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public AssignedNumberDto AssignedNumber { get; set; }
        public DeviceInfoDto DeviceInfo { get; set; }
    }
}
