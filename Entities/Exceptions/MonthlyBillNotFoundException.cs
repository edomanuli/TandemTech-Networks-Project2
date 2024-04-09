using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class MonthlyBillNotFoundException : NotFoundException
    {
        public MonthlyBillNotFoundException(int Id) 
            : base($"Bill with id: {Id} not found.")
        {

        }
    }
}
