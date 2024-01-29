using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastuctureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }   
    }
}
