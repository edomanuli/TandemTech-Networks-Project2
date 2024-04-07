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

        public async Task<IEnumerable<MonthlyBillDto>> GetBillsByUserIdAsync(int userId)
        {
            var bills = await _repositoryManager.MonthlyBill.GetBillsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<MonthlyBillDto>>(bills);
        }

        public async Task<bool> MarkBillAsPaidAsync(int billId)
        {
            var bill = await _repositoryManager.MonthlyBill.GetByIdAsync(billId);
            if (bill == null) {
                throw new NotFoundException($"Bill with ID {billId} not found.");
            };

            bill.IsPaid = true;
            _repositoryManager.MonthlyBill.Update(bill);
            await _repositoryManager.SaveAsync();
            return true;
        }
    }
}
