using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            // Configure relationships
            builder.HasOne(d => d.PlanPhoneNumber)
                .WithMany()
                .HasForeignKey(d => d.PlanPhoneNumberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}