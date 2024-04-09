using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UserPlanNotFoundException : NotFoundException
    {
        public UserPlanNotFoundException(int Id) 
            : base($"The plan with {Id} is not part of your plan.")
        {

        }
    }
}
