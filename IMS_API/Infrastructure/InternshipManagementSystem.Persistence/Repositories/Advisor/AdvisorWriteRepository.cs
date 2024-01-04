using İnternshipManagementSystem.Application.Repositories;
using İnternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Persistence.Contexts;

namespace InternshipManagementSystem.Persistence.Repositories
{
    public class AdvisorWriteRepository : WriteRepository<Advisor>, IAdvisorWriteRepository
    {
        public AdvisorWriteRepository(InternshipManagementSystemDbContext dbContext) : base(dbContext)
        {
        }
    }

}
