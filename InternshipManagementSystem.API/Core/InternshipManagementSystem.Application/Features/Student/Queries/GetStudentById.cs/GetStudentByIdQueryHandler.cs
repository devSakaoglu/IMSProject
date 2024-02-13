using InternshipManagementSystem.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Student.Queries.GetStudentById.cs
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IStudentReadRepository  _studentReadRepository;


        public GetStudentByIdQueryHandler(IStudentReadRepository studentRepository, IStudentWriteRepository studentWriteRepository)
        {
            _studentReadRepository = studentRepository;
            _studentWriteRepository = studentWriteRepository;
        }

        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken )
        {
            var student=  await _studentReadRepository.Table.FirstOrDefaultAsync(x => x.ID == request.Id); 

           return new GetStudentByIdQueryResponse { student = student };


        }

    }
}
