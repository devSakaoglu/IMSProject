using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetStudentsOfAdvisor
{
    public class GetStudentsOfAdvisorQueryHandler : IRequestHandler<GetStudentsOfAdvisorQueryRequest, GetStudentsOfAdvisorQueryResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;

        public GetStudentsOfAdvisorQueryHandler(IAdvisorReadRepository advisorReadRepository)
        {
            _advisorReadRepository = advisorReadRepository;
        }

        public async Task<GetStudentsOfAdvisorQueryResponse> Handle(GetStudentsOfAdvisorQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _advisorReadRepository.Table.Include(x => x.Students).FirstOrDefaultAsync(x => x.ID == request.Id);
            var students = data.Students;
            return new GetStudentsOfAdvisorQueryResponse
            {
                Response = new ResponseModel
                {
                    Data = students,
                    Message = "Successful",
                    IsSuccess = true,
                    StatusCode = 200
                }

            };
                                                                            

        }
    }
}
