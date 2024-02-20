using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetStudentsOfAllAdvisors
{
    public class GetStudentsOfAllAdvisorsQueryHandler : IRequestHandler<GetStudentsOfAllAdvisorsQueryRequest, GetStudentsOfAllAdvisorsQueryResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;
        public async Task<GetStudentsOfAllAdvisorsQueryResponse> Handle(GetStudentsOfAllAdvisorsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = _advisorReadRepository.GetAll().Include(x => x.Students);
            var students = data.SelectMany(x => x.Students).ToList();
            return new GetStudentsOfAllAdvisorsQueryResponse
            {
                Response = new ResponseModel
                {
                    IsSuccess = true,
                    Message= "Successful",
                    StatusCode = 200,
                    Data = students

                }
            };
                                   
        }
    }
}
