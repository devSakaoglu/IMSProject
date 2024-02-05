using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Persistence.Repositories
{
    public class InternshipDocumentWriteRepository : WriteRepository<Domain.Entities.InternshipDocument>, IInternshipDocumentWriteRepository
    {
        public InternshipDocumentWriteRepository(InternshipManagementSystemDbContext dbContext) : base(dbContext)
        {
        }
    }
}
