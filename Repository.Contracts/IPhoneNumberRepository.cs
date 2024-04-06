using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IPhoneNumberRepository
    {
        Task<IEnumerable<PhoneNumber>> GetAllAsync(bool trackChanges);
        Task<PhoneNumber?> GetByIdAsync(int id, bool trackChanges);
        void Create(PhoneNumber phoneNumber);
        void Update(PhoneNumber phoneNumber);
        void Delete(PhoneNumber phoneNumber);
    }

}
