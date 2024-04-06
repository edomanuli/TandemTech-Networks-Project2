using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // Relationships
            builder.HasOne(d => d.AssignedNumber)
                   .WithOne(an => an.Device)
                   .HasForeignKey<Device>(d => d.AssignedNumberId);

            builder.HasOne(d => d.DeviceInfo)
               .WithMany()
               .HasForeignKey(d => d.Id);

            // Seed data
            builder.HasData(
                new Device { Id = 1, AssignedNumberId = 1, DeviceInfoId = 3, Name = "My iPhone 13 Mini", Serial = "EM12345" },
                new Device { Id = 2, AssignedNumberId = 2, DeviceInfoId = 9, Name = "Jake's Galaxy Z Fold 3", Serial = "LM54321" },
                new Device { Id = 3, AssignedNumberId = 3, DeviceInfoId = 15, Name = "Dad's Pixel 3a", Serial = "LM98765" },
                new Device { Id = 4, AssignedNumberId = 4, DeviceInfoId = 22, Name = "Mom's Xiaomi Redmi Note 11", Serial = "LM13579" },
                new Device { Id = 5, AssignedNumberId = 5, DeviceInfoId = 6, Name = "My Samsung Galaxy S21", Serial = "LM24680" },
                new Device { Id = 6, AssignedNumberId = 6, DeviceInfoId = 2, Name = "Sara's iPhone 13 Pro", Serial = "LM11223" },
                new Device { Id = 7, AssignedNumberId = 7, DeviceInfoId = 14, Name = "Brother's Pixel 4 XL", Serial = "OV44444" },
                new Device { Id = 8, AssignedNumberId = 8, DeviceInfoId = 18, Name = "Sister's OnePlus Nord 2", Serial = "OV55555" },
                new Device { Id = 9, AssignedNumberId = 9, DeviceInfoId = 12, Name = "Grandpa's Pixel 5a", Serial = "OV66666" },
                new Device { Id = 10, AssignedNumberId = 10, DeviceInfoId = 20, Name = "Grandma's OnePlus 8 Pro", Serial = "OV77777" },
                new Device { Id = 11, AssignedNumberId = 11, DeviceInfoId = 7, Name = "Uncle's Galaxy Note 20", Serial = "OV88888" },
                new Device { Id = 12, AssignedNumberId = 12, DeviceInfoId = 4, Name = "Aunt's iPhone SE", Serial = "NH12121" },
                new Device { Id = 13, AssignedNumberId = 13, DeviceInfoId = 10, Name = "Cousin's Galaxy S20 FE", Serial = "NH23232" },
                new Device { Id = 14, AssignedNumberId = 14, DeviceInfoId = 17, Name = "My OnePlus 9", Serial = "AV99999" },
                new Device { Id = 15, AssignedNumberId = 15, DeviceInfoId = 25, Name = "Xiaomi Mi Mix 4", Serial = "AV88888" },
                new Device { Id = 16, AssignedNumberId = 16, DeviceInfoId = 13, Name = "Pixel 4a 5G", Serial = "AV77777" },
                new Device { Id = 18, AssignedNumberId = 18, DeviceInfoId = 23, Name = "Xiaomi Mi 11 Lite", Serial = "OL54321" },
                new Device { Id = 19, AssignedNumberId = 19, DeviceInfoId = 11, Name = "Google Pixel 6", Serial = "OL98765" },
                new Device { Id = 20, AssignedNumberId = 21, DeviceInfoId = 19, Name = "OnePlus 8T", Serial = "IS24680" },
                new Device { Id = 21, AssignedNumberId = 22, DeviceInfoId = 8, Name = "Samsung Galaxy A52", Serial = "ET56789" },
                new Device { Id = 22, AssignedNumberId = 23, DeviceInfoId = 16, Name = "OnePlus 9 Pro", Serial = "SP98765" },
                new Device { Id = 23, AssignedNumberId = 24, DeviceInfoId = 1, Name = "iPhone 13", Serial = "SP54321" },
                new Device { Id = 24, AssignedNumberId = 26, DeviceInfoId = 8, Name = "Jacob's Phone", Serial = "JC13579" }
            );
        }
    }
}