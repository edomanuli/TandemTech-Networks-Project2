using AutoMapper;
using DTOs;
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
                //throw new UserNotFoundException(userId);
            }

            var now = DateTime.UtcNow;
            var year = now.Year;
            var month = now.Month;

            var bill = await _repositoryManager.MonthlyBill.GetMonthlyBillByUserAndMonth(userId, year, month);
            
            // Return generic monthly bill if none found
            if (bill == null)
            {
                return new MonthlyBillDto
                {
                    Total = 0,
                    IsPayed = false,
                    BillingDate = new DateTime(year, month, 1),
                    UserId = userId,
                }; ;
            }

            var monthlyBillDto = _mapper.Map<MonthlyBillDto>(bill);
            return monthlyBillDto;
        }
    }
}
