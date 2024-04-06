using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public ICollection<UserPlan>? UserPlans { get; set; }
        public ICollection<MonthlyBill>? Bills { get; set; }
    }
}
