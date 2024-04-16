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

        public async Task<MonthlyBill> GetMonthlyBillByUserAndMonth(int userId, int year, int month)
        {
            return await FindByCondition(bill => bill.UserId == userId &&
                                                  bill.BillingDate.Year == year &&
                                                  bill.BillingDate.Month == month,
                                          trackChanges: false)
                                .Include(bill => bill.PlanBills)
                                    .ThenInclude(planBill => planBill.UserPlan)
                                        .ThenInclude(userPlan => userPlan.PlanInfo)
                                .SingleOrDefaultAsync();
        }
    }
}
