using Microsoft.EntityFrameworkCore;
using System.IO;
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

                if (!string.IsNullOrWhiteSpace(envConnectionString))
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
