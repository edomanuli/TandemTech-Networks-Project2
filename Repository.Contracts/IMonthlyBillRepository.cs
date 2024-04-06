using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contracts
{
    public interface IMonthlyBillRepository : IRepository<MonthlyBill>
    {
        Task<IEnumerable<MonthlyBill>> GetBillsByUserIdAsync(int userId);


    }
}
