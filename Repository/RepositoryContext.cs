using Microsoft.EntityFrameworkCore;
using Entities;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PlanInfo> PlanInfo { get; set; }
        public DbSet<DeviceInfo> DeviceInfo { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<AssignedNumber> AssignedNumbers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<MonthlyBill> MonthlyBills { get; set; }
        public DbSet<PlanBill> PlanBills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PlanInfoConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceInfoConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());

            modelBuilder.ApplyConfiguration(new UserPlanConfiguration());
            modelBuilder.ApplyConfiguration(new AssignedNumberConfiguration());
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());

            modelBuilder.ApplyConfiguration(new MonthlyBillConfiguration());
            modelBuilder.ApplyConfiguration(new PlanBillConfiguration());
        }
    }

}
