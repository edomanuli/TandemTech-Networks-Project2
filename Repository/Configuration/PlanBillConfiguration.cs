using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PlanBillConfiguration : IEntityTypeConfiguration<PlanBill>
    {
        public void Configure(EntityTypeBuilder<PlanBill> builder)
        {
            // Primary Key
            builder.HasKey(pb => pb.Id);

            // Properties
            builder.Property(pb => pb.Amount)
                   .IsRequired()
                   .HasPrecision(18, 2);

            // Relationships

            builder.HasOne(pb => pb.UserPlan)
                   .WithMany()
                   .HasForeignKey(pb => pb.UserPlanId);
        }
    }
}
