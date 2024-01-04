using İnternshipManagementSystem.Application.Repositories;
using İnternshipManagementSystem.Domain.Entities;
using InternshipManagementSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Persistence.Repositories
{
    public class StudentWriteRepository : WriteRepository <Student>, IStudentWriteRepository
    {
        public StudentWriteRepository(InternshipManagementSystemDbContext context) : base(context)
        {
        }
    }   
  
}
