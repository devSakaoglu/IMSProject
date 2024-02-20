using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetStudentsOfAdvisor
{
    public class GetStudentsOfAdvisorQueryRequest : IRequest<GetStudentsOfAdvisorQueryResponse>
    {
        public Guid Id { get; set; }

    }
}
