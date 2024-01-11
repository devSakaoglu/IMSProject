using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Persistence.Contexts;
using InternshipManagementSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InternshipManagementSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this
            IServiceCollection services)
        {
            services.AddDbContext<InternshipManagementSystemDbContext>(options => options.UseNpgsql(Configuration.ConnectionString),ServiceLifetime.Singleton);
            services.AddScoped<IAdvisorReadRepository, AdvisorReadRepository>();
            services.AddScoped<IAdvisorWriteRepository, AdvisorWriteRepository>();
            services.AddScoped<IInternshipReadRepository, InternshipReadRepository>();
            services.AddScoped<IInternshipWriteRepository, InternshipWriteRepository>();
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
        }                      
    }
}
