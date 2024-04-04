using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System.Reflection.Emit;

namespace Repository.Configuration
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            // Seed data
            builder.HasData(
                new PhoneNumber { Id = 1, Number = "2125551234" },
                new PhoneNumber { Id = 2, Number = "2125551235" },
                new PhoneNumber { Id = 3, Number = "2125551236" },
                new PhoneNumber { Id = 4, Number = "2125551237" },
                new PhoneNumber { Id = 5, Number = "4155551234" },
                new PhoneNumber { Id = 6, Number = "4155551235" },
                new PhoneNumber { Id = 7, Number = "4155551236" },
                new PhoneNumber { Id = 8, Number = "4155551237" },
                new PhoneNumber { Id = 9, Number = "3125551234" },
                new PhoneNumber { Id = 10, Number = "3125551235" },
                new PhoneNumber { Id = 11, Number = "3125551236" },
                new PhoneNumber { Id = 12, Number = "3125551237" },
                new PhoneNumber { Id = 13, Number = "2135551234" },
                new PhoneNumber { Id = 14, Number = "2135551235" },
                new PhoneNumber { Id = 15, Number = "2135551236" },
                new PhoneNumber { Id = 16, Number = "2135551237" },
                new PhoneNumber { Id = 17, Number = "2125551238" },
                new PhoneNumber { Id = 18, Number = "2125551239" },
                new PhoneNumber { Id = 19, Number = "2125551240" },
                new PhoneNumber { Id = 20, Number = "2125551241" }
            );
        }
    }
}