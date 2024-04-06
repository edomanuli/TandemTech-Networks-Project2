﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AssignedNumberRepository : Repository<AssignedNumber>, IAssignedNumberRepository
    {
        public AssignedNumberRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<AssignedNumber>> GetByUserPlanIdAsync(int planId)
        {
            return await FindByCondition(an => an.UserPlanId == planId, trackChanges: false)
                .Include(an => an.PhoneNumber)
                .ToListAsync();
        }
    }
}
