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
            builder.Property(b => b.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.UserId)
                   .IsRequired();

            builder.Property(b => b.BillingDate)
                   .IsRequired();

            builder.Property(b => b.Total)
                   .IsRequired()
                   .HasPrecision(18, 2);

            // Relationships
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bills)
                   .HasForeignKey(b => b.UserId);

            builder.HasMany(b => b.PlanBills)
                   .WithOne(bl => bl.MonthlyBill)
                   .HasForeignKey(bl => bl.BillId);

            // Seed Data
            builder.HasData(
                new MonthlyBill { Id = 1, UserId = 1, BillingDate = new DateTime(2024, 4, 1), Total = 30, IsPayed = true },
                new MonthlyBill { Id = 2, UserId = 2, BillingDate = new DateTime(2024, 4, 1), Total = 60, IsPayed = false },
                new MonthlyBill { Id = 3, UserId = 3, BillingDate = new DateTime(2024, 4, 1), Total = 120, IsPayed = true },
                new MonthlyBill { Id = 4, UserId = 4, BillingDate = new DateTime(2024, 4, 1), Total = 40, IsPayed = false },
                new MonthlyBill { Id = 5, UserId = 5, BillingDate = new DateTime(2024, 4, 1), Total = 70, IsPayed = true },
                new MonthlyBill { Id = 6, UserId = 6, BillingDate = new DateTime(2024, 4, 1), Total = 110, IsPayed = false },
                new MonthlyBill { Id = 7, UserId = 7, BillingDate = new DateTime(2024, 4, 1), Total = 60, IsPayed = true },
                new MonthlyBill { Id = 8, UserId = 8, BillingDate = new DateTime(2024, 4, 1), Total = 30, IsPayed = true },
                new MonthlyBill { Id = 9, UserId = 9, BillingDate = new DateTime(2024, 4, 1), Total = 100, IsPayed = false },
                new MonthlyBill { Id = 10, UserId = 10, BillingDate = new DateTime(2024, 4, 1), Total = 60, IsPayed = true }
            );




        }
    }
}
