using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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

            // Seed data
            builder.HasData(
                new AssignedNumber { Id = 1, UserPlanId = 1, PhoneNumberId = 1 },

                new AssignedNumber { Id = 2, UserPlanId = 3, PhoneNumberId = 6 },
                new AssignedNumber { Id = 3, UserPlanId = 3, PhoneNumberId = 7 },
                new AssignedNumber { Id = 4, UserPlanId = 3, PhoneNumberId = 8 },
                new AssignedNumber { Id = 5, UserPlanId = 3, PhoneNumberId = 9 },
                new AssignedNumber { Id = 6, UserPlanId = 3, PhoneNumberId = 10 },

                new AssignedNumber { Id = 7, UserPlanId = 4, PhoneNumberId = 11 },
                new AssignedNumber { Id = 8, UserPlanId = 5, PhoneNumberId = 12 },
                new AssignedNumber { Id = 9, UserPlanId = 5, PhoneNumberId = 13 },
                new AssignedNumber { Id = 10, UserPlanId = 6, PhoneNumberId = 14 },
                new AssignedNumber { Id = 11, UserPlanId = 6, PhoneNumberId = 15 },

                new AssignedNumber { Id = 12, UserPlanId = 7, PhoneNumberId = 16 },
                new AssignedNumber { Id = 13, UserPlanId = 7, PhoneNumberId = 17 },

                new AssignedNumber { Id = 14, UserPlanId = 8, PhoneNumberId = 18 },
                new AssignedNumber { Id = 15, UserPlanId = 9, PhoneNumberId = 19 },
                new AssignedNumber { Id = 16, UserPlanId = 9, PhoneNumberId = 20 },
                new AssignedNumber { Id = 17, UserPlanId = 10, PhoneNumberId = 21 },

                new AssignedNumber { Id = 18, UserPlanId = 11, PhoneNumberId = 22 },
                new AssignedNumber { Id = 19, UserPlanId = 11, PhoneNumberId = 23 },
                new AssignedNumber { Id = 20, UserPlanId = 12, PhoneNumberId = 24 },

                new AssignedNumber { Id = 21, UserPlanId = 13, PhoneNumberId = 25 },

                new AssignedNumber { Id = 22, UserPlanId = 14, PhoneNumberId = 1 },

                new AssignedNumber { Id = 23, UserPlanId = 16, PhoneNumberId = 6 },
                new AssignedNumber { Id = 24, UserPlanId = 17, PhoneNumberId = 7 },
                new AssignedNumber { Id = 25, UserPlanId = 17, PhoneNumberId = 8 },

                new AssignedNumber { Id = 26, UserPlanId = 18, PhoneNumberId = 9 }
            );



        }
    }
}
