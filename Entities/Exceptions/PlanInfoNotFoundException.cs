using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PlanInfoNotFoundException : NotFoundException
    {
        public PlanInfoNotFoundException(int Id) 
            : base($"The plan with the id: {Id} does not exist in our database.")
        {

        }
    }
}
