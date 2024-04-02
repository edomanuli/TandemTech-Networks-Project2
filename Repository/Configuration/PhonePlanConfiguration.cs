using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace Repository.Configuration
{
    public class PhonePlanConfiguration : IEntityTypeConfiguration<PhonePlan>
    {
        public void Configure(EntityTypeBuilder<PhonePlan> builder)
        {
        }
    }
}