using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AssignedNumberNotFoundException : NotFoundException
    {
        public AssignedNumberNotFoundException(int Id) 
            : base($"The phone number with id: {Id} is not assigned.")
        {

        }
    }
}
