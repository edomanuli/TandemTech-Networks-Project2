using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    public class DeviceInfoConfiguration : IEntityTypeConfiguration<DeviceInfo>
    {
        public void Configure(EntityTypeBuilder<DeviceInfo> builder)
        {
            builder.HasKey(di => di.Id);
            
            // Properties
            builder.Property(di => di.Manufacturer).IsRequired().HasMaxLength(100);
            builder.Property(di => di.Model).IsRequired().HasMaxLength(100);
            builder.Property(di => di.ImgUrl).IsRequired(false).HasMaxLength(255);

            // Relationships


            // Seed data
            builder.HasData(
                // Apple
                new DeviceInfo { Id = 1, Manufacturer = "Apple", Model = "iPhone 13" },
                new DeviceInfo { Id = 2, Manufacturer = "Apple", Model = "iPhone 13 Pro" },
                new DeviceInfo { Id = 3, Manufacturer = "Apple", Model = "iPhone 13 Mini" },
                new DeviceInfo { Id = 4, Manufacturer = "Apple", Model = "iPhone SE" },
                new DeviceInfo { Id = 5, Manufacturer = "Apple", Model = "iPhone 12" },

                // Samsung
                new DeviceInfo { Id = 6, Manufacturer = "Samsung", Model = "Galaxy S21" },
                new DeviceInfo { Id = 7, Manufacturer = "Samsung", Model = "Galaxy Note 20" },
                new DeviceInfo { Id = 8, Manufacturer = "Samsung", Model = "Galaxy A52" },
                new DeviceInfo { Id = 9, Manufacturer = "Samsung", Model = "Galaxy Z Fold 3" },
                new DeviceInfo { Id = 10, Manufacturer = "Samsung", Model = "Galaxy S20 FE" },

                // Google
                new DeviceInfo { Id = 11, Manufacturer = "Google", Model = "Pixel 6" },
                new DeviceInfo { Id = 12, Manufacturer = "Google", Model = "Pixel 5a" },
                new DeviceInfo { Id = 13, Manufacturer = "Google", Model = "Pixel 4a 5G" },
                new DeviceInfo { Id = 14, Manufacturer = "Google", Model = "Pixel 4 XL" },
                new DeviceInfo { Id = 15, Manufacturer = "Google", Model = "Pixel 3a" },

                // OnePlus
                new DeviceInfo { Id = 16, Manufacturer = "OnePlus", Model = "OnePlus 9 Pro" },
                new DeviceInfo { Id = 17, Manufacturer = "OnePlus", Model = "OnePlus 9" },
                new DeviceInfo { Id = 18, Manufacturer = "OnePlus", Model = "OnePlus Nord 2" },
                new DeviceInfo { Id = 19, Manufacturer = "OnePlus", Model = "OnePlus 8T" },
                new DeviceInfo { Id = 20, Manufacturer = "OnePlus", Model = "OnePlus 8 Pro" },

                // Xiaomi
                new DeviceInfo { Id = 21, Manufacturer = "Xiaomi", Model = "Xiaomi 11T Pro" },
                new DeviceInfo { Id = 22, Manufacturer = "Xiaomi", Model = "Xiaomi Redmi Note 11" },
                new DeviceInfo { Id = 23, Manufacturer = "Xiaomi", Model = "Xiaomi Mi 11 Lite" },
                new DeviceInfo { Id = 24, Manufacturer = "Xiaomi", Model = "Xiaomi Poco X4 Pro" },
                new DeviceInfo { Id = 25, Manufacturer = "Xiaomi", Model = "Xiaomi Mi Mix 4" }
            );
        }
    }
}
