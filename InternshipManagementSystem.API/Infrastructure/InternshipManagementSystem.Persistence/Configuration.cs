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

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Developmentsadfasdf")
                {
                    return new(configurationManager.GetConnectionString("PosgreSql"));
                }
                else
                {
                    var connectionString = "Server=tcp:imsproject.database.windows.net,1433;Initial Catalog=imsdb;Persist Security Info=False;User ID=imsdb;Password=Imsproject18;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                    //var connectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_DATABASE_CONNECTION");

                    //if (connectionString is null) throw new Exception("Connection string is null");

                    return connectionString;
                }
            }
        }

    }
}
