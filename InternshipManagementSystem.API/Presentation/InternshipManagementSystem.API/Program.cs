using FluentValidation.AspNetCore;
using InternshipManagementSystem.Application.Validators.Advisor;
using InternshipManagementSystem.Application.Validators.Student;
using InternshipManagementSystem.Infrastructure;
using InternshipManagementSystem.Infrastructure.Filters;
using InternshipManagementSystem.Persistence;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "http://localhost:4200")));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateAdvisorValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UpdateAdvisorValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateStudentValidator>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UpdateStudentValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddInfrastuctureServices();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistanceService();


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
