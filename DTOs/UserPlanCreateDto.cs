using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserPlanCreateDto
    {   
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlanInfoId { get; set; }
    }
}
