using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace Repository.Configuration
{
    public class PlanPhoneNumberConfiguration : IEntityTypeConfiguration<PlanPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PlanPhoneNumber> builder)
        {
            // Configure relationships
            builder.HasOne(ppn => ppn.UserPlan)
                .WithMany()
                .HasForeignKey(ppn => ppn.UserPlanId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(ppn => ppn.PhoneNumber)
                .WithMany()
                .HasForeignKey(ppn => ppn.PhoneNumberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}