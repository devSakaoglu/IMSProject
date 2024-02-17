using InternshipManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Internship.Commands.CreateInternship
{
    public class CreateInternshipCommandRequest : IRequest<CreateInternshipCommandResponse>
    {
        public Guid AdvisorID { get; set; }
        public string StudentNo { get; set; }
        public InternshipStatus? Status { get; set; }
        public Guid? FormID { get; set; }
        public Guid? ExcelID { get; set; }
    }
}
