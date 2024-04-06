using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            // Define properties
            builder.Property(u => u.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            // Define relationships
            builder.HasMany(u => u.UserPlans)
                   .WithOne(up => up.User)
                   .HasForeignKey(up => up.UserId)
                   .IsRequired();

            builder.HasMany(u => u.Bills)
                   .WithOne(b => b.User)
                   .HasForeignKey(b => b.UserId)
                   .IsRequired();
            
            // Configure relationships
            builder.HasMany(u => u.UserPlans)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Seed data
            builder.HasData(
                new User { Id = 1, FirstName = "Emma", LastName = "Johnson", Email = "emma.johnson@example.com" },
                new User { Id = 2, FirstName = "Liam", LastName = "Williams", Email = "liam.williams@example.com" },
                new User { Id = 3, FirstName = "Olivia", LastName = "Brown", Email = "olivia.brown@example.com" },
                new User { Id = 4, FirstName = "Noah", LastName = "Jones", Email = "noah.jones@example.com" },
                new User { Id = 5, FirstName = "Ava", LastName = "Garcia", Email = "ava.garcia@example.com" },
                new User { Id = 6, FirstName = "Oliver", LastName = "Miller", Email = "oliver.miller@example.com" },
                new User { Id = 7, FirstName = "Isabella", LastName = "Davis", Email = "isabella.davis@example.com" },
                new User { Id = 8, FirstName = "Ethan", LastName = "Martinez", Email = "ethan.martinez@example.com" },
                new User { Id = 9, FirstName = "Sophia", LastName = "Rodriguez", Email = "sophia.rodriguez@example.com" },
                new User { Id = 10, FirstName = "Jacob", LastName = "Wilson", Email = "jacob.wilson@example.com" }
             );
        }
    }
}
