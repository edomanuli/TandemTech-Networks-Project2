using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class MonthlyBillConfiguration : IEntityTypeConfiguration<MonthlyBill>
    {
        public void Configure(EntityTypeBuilder<MonthlyBill> builder)
        {
            // Primary Key
            builder.HasKey(b => b.Id);

            // Properties
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.BillingDate).IsRequired();
            builder.Property(b => b.Total).IsRequired().HasPrecision(18, 2);
            builder.Property(b => b.IsPaid).IsRequired();

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.MonthlyBills)
                   .HasForeignKey(b => b.UserId);

            builder.HasMany(mb => mb.PlanBills)
               .WithOne(pb => pb.MonthlyBill)
               .HasForeignKey(pb => pb.MonthlyBillId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
