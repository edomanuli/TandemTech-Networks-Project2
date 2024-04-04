using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System.Numerics;

namespace Repository.Configuration
{
    public class PhonePlanConfiguration : IEntityTypeConfiguration<PhonePlan>
    {
        public void Configure(EntityTypeBuilder<PhonePlan> builder)
        {
            builder.HasData(
                new PhonePlan { 
                    Id = 1, Name = "Basic Plan", 
                    Price = 30, DeviceLimit = 1, 
                    DataLimit = 5, 
                    Description = "Stay connected with our Basic Plan, perfect for calls, messages, and browsing with a generous 5GB data limit." 
                },
                new PhonePlan { 
                    Id = 2, Name = "Standard Plan", 
                    Price = 40, DeviceLimit = 2, 
                    DataLimit = 10, 
                    Description = "Upgrade to our Standard Plan for more data and the flexibility to connect two devices. Enjoy browsing, streaming, and sharing with 10GB of data." 
                },
                new PhonePlan { 
                    Id = 3, Name = "Premium Plan", 
                    Price = 60, 
                    DeviceLimit = 5, 
                    DataLimit = 0, 
                    Description = "Get the ultimate experience with our Premium Plan. Stream, game, and connect with multiple devices effortlessly with unlimited data." 
                }
);
        }
    }
}