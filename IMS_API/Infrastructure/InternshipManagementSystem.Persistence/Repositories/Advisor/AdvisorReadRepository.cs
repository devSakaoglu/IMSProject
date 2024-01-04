using İnternshipManagementSystem.Application.Repositories;
using İnternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Persistence.Contexts;

namespace InternshipManagementSystem.Persistence.Repositories
{
    public class AdvisorReadRepository : ReadRepository<Advisor>, IAdvisorReadRepository
    {
        public AdvisorReadRepository(InternshipManagementSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
