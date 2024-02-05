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


                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    return new(configurationManager.GetConnectionString("PosgreSql"));
                }
                else
                {
                    var envConnectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DEFAULT");
                    return envConnectionString;
                }

            }
        }
    }
}
