using FluentValidation.AspNetCore;
using InternshipManagementSystem.Application.Validators.Advisor;
using InternshipManagementSystem.Application.Validators.Student;
using InternshipManagementSystem.Infrastructure;
using InternshipManagementSystem.Infrastructure.Filters;
using InternshipManagementSystem.Persistence;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InternshipManagementSystem.Application;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:", "http://localhost:")));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateAdvisorValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UpdateAdvisorValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateStudentValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UpdateStudentValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
    .AddJsonOptions(options =>
    {
       options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
       options.JsonSerializerOptions.MaxDepth = 0; // Set the maximum depth to 0 to disable circular reference handling
    });

builder.Services.AddInfrastuctureServices();

builder.Services.AddInfrastuctureServices();

builder.Services.AddInfrastuctureServices();
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistanceService();
builder.Services.AddAuthentication("Student")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))

        };

    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
