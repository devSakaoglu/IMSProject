﻿using InternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternshipManagementSystem.Persistence.Contexts
{
    public class InternshipManagementSystemDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public InternshipManagementSystemDbContext(DbContextOptions<InternshipManagementSystemDbContext> options) : base(options)
        {
            
        }
        DbSet<Advisor> Advisors { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Internship> Internships { get; set; }
        DbSet<InternshipDocument> InternshipDocuments { get; set; }
        DbSet<InternshipApplicationInfoForAdviserExcel> InternshipApplicationInfoForAdviserExcels { get; set; }
        DbSet<InternAppAcceptForm> InternAppAcceptForms { get; set; }
        DbSet<SPAS> SPASs { get; set; }
        DbSet<AttendanceSchedule> AttendanceSchedules { get; set; }
        DbSet<WeeklyWorkPlan> WeeklyWorkPlans { get; set; }
        DbSet<InternshipBook> InternshipBooks { get; set; }
        //DbSet<InternshipFiles> InternshipFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Student>()
            // .HasIndex(s => s.StudentNo)
            // .IsUnique();
            
            // builder.Entity<Advisor>()
            // .HasIndex(s => s.Email)
            // .IsUnique();
            
            builder.Entity<AppRole>()
                .HasData(new List<AppRole>()
                {
                    new()
                    {
                        Id = "1",
                        Name = "Student",
                        NormalizedName = "STUDENT"
                    },
                    new()
                    {
                        Id = "2",
                        Name = "Advisor",
                        NormalizedName = "ADVISOR"
                    },
                    new()
                    {
                        Id = "3",
                        Name = "Super",
                        NormalizedName = "SUPER"
                    }
                });

            builder.Entity<Advisor>()
                .HasData(new List<Advisor>()
                {
                    new()
                    {
                        ID = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                        Email = "mzahitgurbuz@dogus.edu.tr",
                        TC_NO = "12345678910",
                        AdvisorName = "M. Zahit ",
                        AdvisorSurname = "Gurbuz",
                        DepartmentName = "Computer Science",
                        ProgramName = "Computer Engineering",
                        Address = "Istanbul",
                        FacultyName = "Engineering"
                    }
                });
            base.OnModelCreating(builder);

        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : track edilen verleri yakalar insert disinda track edilen verileri yakalar
            //update operasyonlarinda track edilen verileri yakalar
            var datas = ChangeTracker
                .Entries<BaseEntity>();   

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Unchanged:
                        return base.SaveChangesAsync(cancellationToken);                    
                        break;

                    //case EntityState.Detached:
                    //    break;


                    //case EntityState.Deleted:
                    //    break;


                    default:
                        return base.SaveChangesAsync(cancellationToken);
                        break;
                }
            }


            return base.SaveChangesAsync(cancellationToken);


        }
    



    }
}
