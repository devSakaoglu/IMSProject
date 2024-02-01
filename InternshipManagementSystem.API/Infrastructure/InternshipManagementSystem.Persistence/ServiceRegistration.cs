﻿using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Domain.Entities.Identity;
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
            services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<InternshipManagementSystemDbContext>();


            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                services.AddDbContext<InternshipManagementSystemDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);
            }
            else
            {
                services.AddDbContext<InternshipManagementSystemDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
            }

            services.AddScoped<IAdvisorReadRepository, AdvisorReadRepository>();
            services.AddScoped<IAdvisorWriteRepository, AdvisorWriteRepository>();
            services.AddScoped<IInternshipReadRepository, InternshipReadRepository>();
            services.AddScoped<IInternshipWriteRepository, InternshipWriteRepository>();
            services.AddScoped<IStudentReadRepository, StudentReadRepository>();
            services.AddScoped<IStudentWriteRepository, StudentWriteRepository>();
        }
    }
}
