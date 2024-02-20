using InternshipManagementSystem.Application.Features.Advisor.Queries.GetAdvisorNameByInternshipId;
using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Student
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IStudentReadRepository  _studentReadRepository;
        private readonly IAdvisorReadRepository _advisorReadRepository;
        private readonly IMediator _mediator;

        public GetStudentByIdQueryHandler(IStudentWriteRepository studentWriteRepository, IStudentReadRepository studentReadRepository, IAdvisorReadRepository advisorReadRepository, IMediator mediator)
        {
            _studentWriteRepository = studentWriteRepository;
            _studentReadRepository = studentReadRepository;
            _advisorReadRepository = advisorReadRepository;
            _mediator = mediator;
        }

        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken )
        {
            var student=  await _studentReadRepository.Table.FirstOrDefaultAsync(x => x.ID == request.Id);
            GetAdvisorNameByInternshipIdResponse  response= await _mediator.Send(new GetAdvisorNameByInternshipIdRequest { StudentId  =request.Id});
            if (student is not null)
            {
                student.AdvisorFullName = response.Response.Data.ToString();
            }
            if (student == null)
            {
                return new GetStudentByIdQueryResponse { Response=new()
                {
                    Data = null,
                    Message = "Student not found",
                    IsSuccess = false,
                    StatusCode = 404
                }
                };
            }
            else
            {
                return new GetStudentByIdQueryResponse { Response = new()
                {
                    Data = student,
                    Message = "Student found",
                    IsSuccess = true,
                    StatusCode = 200
                }
                };
            }


        }

    }
}
