using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Persistence.Contexts;

namespace InternshipManagementSystem.Persistence.Repositories
{
    public class InternshipDocumentReadRepository : ReadRepository<Domain.Entities.InternshipDocument>, IInternshipDocumentReadRepository
    {
        public InternshipDocumentReadRepository(InternshipManagementSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
