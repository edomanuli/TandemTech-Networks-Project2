using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumber>
    {
        Task<PhoneNumber> GetUnassignedPhoneNumberAsync();
    }
}
