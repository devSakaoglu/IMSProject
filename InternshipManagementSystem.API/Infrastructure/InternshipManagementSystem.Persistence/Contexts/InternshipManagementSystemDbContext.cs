using InternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Domain.Entities.AppUser;
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
