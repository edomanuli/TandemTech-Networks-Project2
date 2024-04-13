using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class MonthlyBillConfiguration : IEntityTypeConfiguration<MonthlyBill>
    {
        public void Configure(EntityTypeBuilder<MonthlyBill> builder)
        {
            builder.HasKey(b => b.Id);

            // Properties
            builder.Property(b => b.UserId)
                   .IsRequired();

            builder.Property(b => b.BillingDate)
                   .IsRequired();

            builder.Property(b => b.Total)
                   .HasPrecision(18, 2);

            builder.Property(b => b.IsPaid);

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bills)
                   .HasForeignKey(b => b.UserId);

            builder.HasMany(b => b.PlanBills)
                   .WithOne(bl => bl.MonthlyBill)
                   .HasForeignKey(bl => bl.BillId);

            // Seed Data





        }
    }
}
