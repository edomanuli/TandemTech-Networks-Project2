using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class MonthlyBillRepository : Repository<MonthlyBill>, IMonthlyBillRepository
    {
        public MonthlyBillRepository(RepositoryContext context) : base(context) { }

        public async Task<IEnumerable<MonthlyBill>> GetBillsByUserIdAsync(int userId)
        {
            return await FindByCondition(mb => mb.UserId == userId, trackChanges: false)
                             .Include(mb => mb.PlanBills)
                             .ToListAsync();
        }
    }
}
