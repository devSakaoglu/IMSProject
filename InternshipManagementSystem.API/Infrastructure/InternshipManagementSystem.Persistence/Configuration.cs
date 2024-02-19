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
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Deasdsavelopment")
                {
                    ConfigurationManager configurationManager = new();
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/InternshipManagementSystem.API"));
                    configurationManager.AddJsonFile("appsettings.json");

                    return new(configurationManager.GetConnectionString("PosgreSql"));
                }
                else
                {
                    //var envConnectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DEFAULT");
                    return "Server=postgreimsdb.postgres.database.azure.com;Database=postgres;Port=5432;User Id=postgreuser;Password=Imsproject18;Ssl Mode=Require;";
                }

            }
        }
    }
}
