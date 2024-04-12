using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Properties
            builder.Property(u => u.FirstName)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Relationships
            builder.HasMany(u => u.UserPlans)
                   .WithOne(up => up.User)
                   .HasForeignKey(up => up.UserId)
                   .IsRequired();

            builder.HasMany(u => u.Bills)
                   .WithOne(b => b.User)
                   .HasForeignKey(b => b.UserId)
                   .IsRequired();

            //Seed Data
            var hasher = new PasswordHasher<User>();

            var anuli = new User
            {
                Id = 3,
                UserName = "anuli",
                NormalizedUserName = "ANULI",
                Email = "anuli@example.com",
                NormalizedEmail = "ANULI@EXAMPLE.COM",
                FirstName = "Anuli",
                LastName = "Edom"
            };
            anuli.PasswordHash = hasher.HashPassword(anuli, "12345");

            var chris = new User
            {
                Id = 5,
                UserName = "chris",
                NormalizedUserName = "CHRIS",
                Email = "CHRIS@example.com",
                NormalizedEmail = "CHRIS@EXAMPLE.COM",
                FirstName = "Chris",
                LastName = "Leipold"
            };
            chris.PasswordHash = hasher.HashPassword(chris, "12345");

            builder.HasData(
                anuli,
                chris,
                new User { Id = 1, FirstName = "Olivia", LastName = "Brown", Email = "olivia.brown@example.com" },
                new User { Id = 4, FirstName = "Noah", LastName = "Jones", Email = "noah.jones@example.com" },
                new User { Id = 2, FirstName = "Ava", LastName = "Garcia", Email = "ava.garcia@example.com" },
                new User { Id = 6, FirstName = "Oliver", LastName = "Miller", Email = "oliver.miller@example.com" },
                new User { Id = 7, FirstName = "Isabella", LastName = "Davis", Email = "isabella.davis@example.com" },
                new User { Id = 8, FirstName = "Ethan", LastName = "Martinez", Email = "ethan.martinez@example.com" },
                new User { Id = 9, FirstName = "Sophia", LastName = "Rodriguez", Email = "sophia.rodriguez@example.com" },
                new User { Id = 10, FirstName = "Jacob", LastName = "Wilson", Email = "jacob.wilson@example.com" }
             );
        }
    }
}
