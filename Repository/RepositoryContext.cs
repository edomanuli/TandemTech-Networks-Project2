using Microsoft.EntityFrameworkCore;
using Entities;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PhonePlan> PhonePlans { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<PlanPhoneNumber> PlanPhoneNumbers { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PhonePlanConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new UserPlanConfiguration());
            modelBuilder.ApplyConfiguration(new PlanPhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        }
    }
}
