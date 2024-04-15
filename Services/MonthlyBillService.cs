using AutoMapper;
using DTOs;
using Entities;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MonthlyBillService : IMonthlyBillService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MonthlyBillService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<MonthlyBillDto> GetUserBill(int userId)
        {
            // Check if user exists
            var user = await _repositoryManager.User.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception($"No user found with ID {userId}.");
            }

            var now = DateTime.UtcNow;
            var year = now.Year;
            var month = now.Month;

            // If monthly bill exists, return it
            var bill = await _repositoryManager.MonthlyBill.GetMonthlyBillByUserAndMonth(userId, year, month);
            if (bill != null)
            {
                return _mapper.Map<MonthlyBillDto>(bill);
            }

            // If no monthly bill, create one
            var billingDate = new DateTime(year, month, 1);
            var userPlans = await _repositoryManager.UserPlan.GetByUserIdAsync(userId);
            var eligibleUserPlans = userPlans.Where(up => up.EnrollmentDate < billingDate).ToList();

            var newBill = new MonthlyBill
            {
                UserId = userId,
                BillingDate = billingDate,
                Total = eligibleUserPlans.Sum(up => up.PlanInfo.Price),
                IsPaid = false,
                PlanBills = eligibleUserPlans.Select(up => new PlanBill
                {
                    UserPlanId = up.Id,
                    Amount = up.PlanInfo.Price
                }).ToList()
            };

            _repositoryManager.MonthlyBill.Create(newBill);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<MonthlyBillDto>(newBill);
        }
    }
}
