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
            builder.HasData(
                new PlanBill { Id = 1, BillId = 1, BillingDate = new DateTime(2024, 4, 1), Amount = 30 },
                
                new PlanBill { Id = 2, BillId = 2, BillingDate = new DateTime(2024, 4, 1), Amount = 60 },
                
                new PlanBill { Id = 3, BillId = 3, BillingDate = new DateTime(2024, 4, 1), Amount = 30 },
                new PlanBill { Id = 4, BillId = 3, BillingDate = new DateTime(2024, 4, 1), Amount = 30 },
                new PlanBill { Id = 5, BillId = 3, BillingDate = new DateTime(2024, 4, 1), Amount = 60 },
                
                new PlanBill { Id = 6, BillId = 4, BillingDate = new DateTime(2024, 4, 1), Amount = 40 },
                
                new PlanBill { Id = 7, BillId = 5, BillingDate = new DateTime(2024, 4, 1), Amount = 30 },
                new PlanBill { Id = 8, BillId = 5, BillingDate = new DateTime(2024, 4, 1), Amount = 40 },
                
                new PlanBill { Id = 9, BillId = 6, BillingDate = new DateTime(2024, 4, 1), Amount = 30 },
                new PlanBill { Id = 10, BillId = 6, BillingDate = new DateTime(2024, 4, 1), Amount = 40 },
                new PlanBill { Id = 11, BillId = 6, BillingDate = new DateTime(2024, 4, 1), Amount = 40 },
                
                new PlanBill { Id = 12, BillId = 7, BillingDate = new DateTime(2024, 4, 1), Amount = 60 },
                
                new PlanBill { Id = 13, BillId = 8, BillingDate = new DateTime(2024, 4, 1), Amount = 30 },
                
                new PlanBill { Id = 14, BillId = 9, BillingDate = new DateTime(2024, 4, 1), Amount = 40 },
                new PlanBill { Id = 15, BillId = 9, BillingDate = new DateTime(2024, 4, 1), Amount = 60 },
                
                new PlanBill { Id = 16, BillId = 10, BillingDate = new DateTime(2024, 4, 1), Amount = 60 }
            );


        }
    }
}
