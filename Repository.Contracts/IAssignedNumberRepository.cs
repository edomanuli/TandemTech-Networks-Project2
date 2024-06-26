﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IAssignedNumberRepository : IRepository<AssignedNumber>
    {
        Task<IEnumerable<AssignedNumber>> GetAssignedNumbersByUserIdAsync(int userId);
        Task<IEnumerable<AssignedNumber>> GetByUserPlanIdAsync(int userPlanId);
        Task<AssignedNumber> GetAssignedNumberByIdAsync(int id);
    }

}
