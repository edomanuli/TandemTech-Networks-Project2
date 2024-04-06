using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IAssignedNumberRepository
    {
        Task<IEnumerable<AssignedNumber>> GetAllAsync();
        Task<AssignedNumber?> GetByIdAsync(int id);
        void Create(AssignedNumber assignedNumber);
        void Update(AssignedNumber assignedNumber);
        void Delete(AssignedNumber assignedNumber);

        Task<IEnumerable<AssignedNumber>> GetByPlanIdAsync(int planId);
    }

}
