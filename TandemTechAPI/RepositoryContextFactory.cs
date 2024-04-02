using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace TandemTechAPI
{
    internal class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    options => options.MigrationsAssembly("TandemTechAPI"));

            return new RepositoryContext(options.Options);
        }
    }
}
