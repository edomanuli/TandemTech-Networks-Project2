using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Repository.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(d => d.Id);
            
            // Properties
            builder.Property(d => d.Serial).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Name).HasMaxLength(100);
            builder.Property(e => e.AssignedNumberId).IsRequired(false);

            // Relationships
            builder.HasOne(d => d.AssignedNumber)
            .WithOne(a => a.Device)
            .HasForeignKey<Device>(d => d.AssignedNumberId);

            builder.HasOne(d => d.DeviceInfo)
                   .WithMany()
                   .HasForeignKey(d => d.DeviceInfoId);

            // Seed data
            builder.HasData(
                new Device { Id = 1, AssignedNumberId = 1, DeviceInfoId = 3, Name = "My iPhone 13 Mini", Serial = "EM12345" },
                new Device { Id = 2, AssignedNumberId = 2, DeviceInfoId = 9, Name = "Jake's Galaxy Z Fold 3", Serial = "LM54321" },
                new Device { Id = 3, AssignedNumberId = 3, DeviceInfoId = 15, Name = "Dad's Pixel 3a", Serial = "LM98765" },
                new Device { Id = 4, AssignedNumberId = 4, DeviceInfoId = 22, Name = "Mom's Xiaomi Redmi Note 11", Serial = "LM13579" },
                new Device { Id = 5, AssignedNumberId = 5, DeviceInfoId = 6, Name = "My Samsung Galaxy S21", Serial = "LM24680" },
                new Device { Id = 6, AssignedNumberId = 6, DeviceInfoId = 2, Name = "Sara's iPhone 13 Pro", Serial = "LM11223" }
            );
        }
    }
}