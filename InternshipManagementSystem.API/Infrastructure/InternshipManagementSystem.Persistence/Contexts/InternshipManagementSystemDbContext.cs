using InternshipManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternshipManagementSystem.Persistence.Contexts
{
    public class InternshipManagementSystemDbContext : DbContext
    {
        public InternshipManagementSystemDbContext(DbContextOptions<InternshipManagementSystemDbContext> options) : base(options)
        {

        }
        DbSet<Advisor> Advisors { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Internship> Internships { get; set; }

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
                        // Burada ek bir işlem yapmak istiyorsanız ekleyebilirsiniz.
                        break;

                    case EntityState.Detached:
                        throw new NotImplementedException();

                    case EntityState.Deleted:
                        throw new NotImplementedException();

                    default:
                        throw new NotImplementedException();
                }
            }


            return base.SaveChangesAsync(cancellationToken);


        }
        //override protected void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Advisor>().Property(e => e.id).ValueGeneratedOnAdd();
        //    modelBuilder.Entity<Student>().Property(e => e.id).ValueGeneratedOnAdd();
        //    modelBuilder.Entity<Internship>().Property(e => e.id).ValueGeneratedOnAdd();
        //}


    }
}
