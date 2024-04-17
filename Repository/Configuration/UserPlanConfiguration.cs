using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace Repository.Configuration
{
    internal class UserPlanConfiguration : IEntityTypeConfiguration<UserPlan>
    {
        public void Configure(EntityTypeBuilder<UserPlan> builder)
        {
            // Properties
            builder.HasKey(up => up.Id);
            builder.Property(up => up.EnrollmentDate).IsRequired();

            // Relationships
            builder.HasOne(up => up.User)
                   .WithMany(u => u.UserPlans)
                   .HasForeignKey(up => up.UserId);

            builder.HasOne(up => up.PlanInfo)
                   .WithMany(pi => pi.UserPlans)
                   .HasForeignKey(up => up.PlanInfoId);

            builder
                .HasMany(up => up.AssignedNumbers)
                .WithOne(an => an.UserPlan)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            builder.HasData(
                
                // Anuli's Plans
                new UserPlan { Id = 1, UserId = 1, PlanInfoId = 1, EnrollmentDate = new DateTime(2023, 1, 1) }, 
                new UserPlan { Id = 2, UserId = 1, PlanInfoId = 2, EnrollmentDate = new DateTime(2023, 1, 1) },
                new UserPlan { Id = 3, UserId = 1, PlanInfoId = 3, EnrollmentDate = new DateTime(2023, 1, 1) },

                // Chris's Plans
                new UserPlan { Id = 4, UserId = 2, PlanInfoId = 1, EnrollmentDate = new DateTime(2023, 1, 1) },
                new UserPlan { Id = 5, UserId = 2, PlanInfoId = 2, EnrollmentDate = new DateTime(2023, 1, 1) },
                new UserPlan { Id = 6, UserId = 2, PlanInfoId = 3, EnrollmentDate = new DateTime(2023, 1, 1) }
            );
        }
    }
}