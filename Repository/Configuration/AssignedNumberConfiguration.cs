using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace Repository.Configuration
{
    public class AssignedNumberConfiguration : IEntityTypeConfiguration<AssignedNumber>
    {
        public void Configure(EntityTypeBuilder<AssignedNumber> builder)
        {
            builder.HasKey(an => an.Id);

            // Properties
            builder.Property(an => an.UserPlanId).IsRequired();
            builder.Property(an => an.PhoneNumberId).IsRequired();

            // Relationships
            builder.HasOne(an => an.UserPlan)
                   .WithMany(up => up.AssignedNumbers)
                   .HasForeignKey(an => an.UserPlanId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(an => an.PhoneNumber)
                   .WithOne(pn => pn.AssignedNumber)
                   .HasForeignKey<AssignedNumber>(an => an.PhoneNumberId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(an => an.Device)
                .WithOne(d => d.AssignedNumber)
                .HasForeignKey<Device>(d => d.AssignedNumberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            builder.HasData(
                new AssignedNumber { Id = 1, UserPlanId = 1, PhoneNumberId = 1 },
                new AssignedNumber { Id = 2, UserPlanId = 2, PhoneNumberId = 6 },
                new AssignedNumber { Id = 3, UserPlanId = 3, PhoneNumberId = 7 },
                new AssignedNumber { Id = 4, UserPlanId = 4, PhoneNumberId = 8 },
                new AssignedNumber { Id = 5, UserPlanId = 5, PhoneNumberId = 9 },
                new AssignedNumber { Id = 6, UserPlanId = 6, PhoneNumberId = 10 }
            );



        }
    }
}
