using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Queries.Student.GetStudentById.cs
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        public Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
