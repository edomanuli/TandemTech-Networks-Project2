using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(pn => pn.Id);

            // Properties
            builder.Property(pn => pn.Number)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(pn => pn.IsPorted).IsRequired();

            builder.HasIndex(pn => pn.Number).IsUnique();

            // Relationships


            // Seed data
            builder.HasData(
                new PhoneNumber { Id = 1, Number = "6035550100" },
                new PhoneNumber { Id = 2, Number = "6035550101" },
                new PhoneNumber { Id = 3, Number = "6035550102" },
                new PhoneNumber { Id = 4, Number = "6035550103" },
                new PhoneNumber { Id = 5, Number = "6035550104" },

                new PhoneNumber { Id = 6, Number = "2025550100" },
                new PhoneNumber { Id = 7, Number = "2025550101" },
                new PhoneNumber { Id = 8, Number = "2025550102" },
                new PhoneNumber { Id = 9, Number = "2025550103" },
                new PhoneNumber { Id = 10, Number = "2025550104" },

                new PhoneNumber { Id = 11, Number = "3055550100" },
                new PhoneNumber { Id = 12, Number = "3055550101" },
                new PhoneNumber { Id = 13, Number = "3055550102" },
                new PhoneNumber { Id = 14, Number = "3055550103" },
                new PhoneNumber { Id = 15, Number = "3055550104" },

                new PhoneNumber { Id = 16, Number = "4155550100" },
                new PhoneNumber { Id = 17, Number = "4155550101" },
                new PhoneNumber { Id = 18, Number = "4155550102" },
                new PhoneNumber { Id = 19, Number = "4155550103" },
                new PhoneNumber { Id = 20, Number = "4155550104" },

                new PhoneNumber { Id = 21, Number = "7025550100" },
                new PhoneNumber { Id = 22, Number = "7025550101" },
                new PhoneNumber { Id = 23, Number = "7025550102" },
                new PhoneNumber { Id = 24, Number = "7025550103" },
                new PhoneNumber { Id = 25, Number = "7025550104" }
            );
        }
    }
}