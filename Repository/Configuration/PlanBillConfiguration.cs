using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PlanBillConfiguration : IEntityTypeConfiguration<PlanBill>
    {
        public void Configure(EntityTypeBuilder<PlanBill> builder)
        {
            // Properties
            builder.HasKey(bl => bl.Id);
            builder.Property(bl => bl.BillingDate).IsRequired();
            builder.Property(bl => bl.Amount).IsRequired().HasPrecision(18, 2);

            // Relationships
            builder.HasOne(bl => bl.MonthlyBill)
                   .WithMany(b => b.PlanBills)
                   .HasForeignKey(bl => bl.BillId);

            // Seed data


        }
    }
}
