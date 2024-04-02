using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace Repository.Configuration
{
    internal class UserPlanConfiguration : IEntityTypeConfiguration<UserPlan>
    {
        public void Configure(EntityTypeBuilder<UserPlan> builder)
        {
            // Configure relationships
            builder.HasOne(up => up.User)
                .WithMany(u => u.UserPlans)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade); // or .SetNull depending on your logic
            
            builder.HasOne(up => up.PhonePlan)
                .WithMany()
                .HasForeignKey(up => up.PhonePlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}