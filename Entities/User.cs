using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<UserPlan>? UserPlans { get; set; }
        public ICollection<MonthlyBill>? MonthlyBills { get; set; }
    }
}
