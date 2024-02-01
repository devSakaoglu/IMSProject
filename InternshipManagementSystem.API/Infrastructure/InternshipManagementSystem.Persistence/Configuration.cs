using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternshipManagementSystem.Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {

            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/InternshipManagementSystem.API"));
                configurationManager.AddJsonFile("appsettings.json");

                var envConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                {
                    return envConnectionString;
                }
                else
                {
                    return new(configurationManager.GetConnectionString("PosgreSql"));
                }

            }
        }
    }
}
