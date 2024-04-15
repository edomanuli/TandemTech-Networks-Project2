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

            //Seed Data
            var hasher = new PasswordHasher<User>();

            var anuli = new User
            {
                Id = 1,
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
                Id = 2,
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
                chris
             );
        }
    }
}
