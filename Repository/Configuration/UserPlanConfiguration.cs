using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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

            // Seed data
            builder.HasData(
                new UserPlan { Id = 1, UserId = 1, PlanInfoId = 1, EnrollmentDate = new DateTime(2024, 1, 1) },
                
                new UserPlan { Id = 3, UserId = 2, PlanInfoId = 3, EnrollmentDate = new DateTime(2024, 1, 1) },
                
                new UserPlan { Id = 4, UserId = 3, PlanInfoId = 1, EnrollmentDate = new DateTime(2024, 1, 1) },
                new UserPlan { Id = 5, UserId = 3, PlanInfoId = 1, EnrollmentDate = new DateTime(2024, 2, 1) },
                new UserPlan { Id = 6, UserId = 3, PlanInfoId = 3, EnrollmentDate = new DateTime(2024, 4, 1) },
                
                new UserPlan { Id = 7, UserId = 4, PlanInfoId = 2, EnrollmentDate = new DateTime(2024, 2, 1) },
               
                new UserPlan { Id = 8, UserId = 5, PlanInfoId = 1, EnrollmentDate = new DateTime(2024, 3, 1) },
                new UserPlan { Id = 9, UserId = 5, PlanInfoId = 2, EnrollmentDate = new DateTime(2024, 3, 1) },
                
                new UserPlan { Id = 10, UserId = 6, PlanInfoId = 1, EnrollmentDate = new DateTime(2024, 1, 1) },
                new UserPlan { Id = 11, UserId = 6, PlanInfoId = 2, EnrollmentDate = new DateTime(2024, 3, 1) },
                new UserPlan { Id = 12, UserId = 6, PlanInfoId = 2, EnrollmentDate = new DateTime(2024, 4, 1) },
                
                new UserPlan { Id = 13, UserId = 7, PlanInfoId = 3, EnrollmentDate = new DateTime(2024, 1, 1) },
                
                new UserPlan { Id = 14, UserId = 8, PlanInfoId = 1, EnrollmentDate = new DateTime(2024, 3, 1) },
                
                new UserPlan { Id = 16, UserId = 9, PlanInfoId = 2, EnrollmentDate = new DateTime(2024, 2, 1) },
                new UserPlan { Id = 17, UserId = 9, PlanInfoId = 3, EnrollmentDate = new DateTime(2024, 4, 1) },
                
                new UserPlan { Id = 18, UserId = 10, PlanInfoId = 3, EnrollmentDate = new DateTime(2024, 4, 1) }
            );
        }
    }
}