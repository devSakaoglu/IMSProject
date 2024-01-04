using İnternshipManagementSystem.Application.Repositories;
using İnternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Persistence.Contexts;

namespace InternshipManagementSystem.Persistence.Repositories
{
    public class InternshipWriteRepository : WriteRepository<Internship>, IInternshipWriteRepository
    {
        public InternshipWriteRepository(InternshipManagementSystemDbContext context) : base(context)
        {
        }
    }
}
