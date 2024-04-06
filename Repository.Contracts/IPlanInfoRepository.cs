﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contracts
{
    public interface IPlanInfoRepository
    {
        Task<PlanInfo?> GetPlanInfoAsync(int phonePlanId, bool trackChanges);
        Task<IEnumerable<PlanInfo>> GetAllPlansAsync();
        void DeletePlanInfoAsync(PlanInfo phonePlan);
    }
}