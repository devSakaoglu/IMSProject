using InternshipManagementSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InternshipManagementSystem.Persistence
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InternshipManagementSystemDbContext>
    {
        public InternshipManagementSystemDbContext CreateDbContext(string[] args)
        {
            //ConfigurationManager configurationManager = new();
            //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/InternshipManagementSystem.API"));
            //configurationManager.AddJsonFile("appsettings.json");

            DbContextOptionsBuilder<InternshipManagementSystemDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
                                      
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
