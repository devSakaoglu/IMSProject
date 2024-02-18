using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetAdvisorById
{
    public class GetAdvisorByIdQueryHandler : IRequestHandler<GetAdvisorByIdQueryRequest, GetAdvisorByIdQueryResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;

        public GetAdvisorByIdQueryHandler(IAdvisorReadRepository advisorReadRepository)
        {
            _advisorReadRepository = advisorReadRepository;
        }

        public async Task<GetAdvisorByIdQueryResponse> Handle(GetAdvisorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(request.Id, false);
            return new GetAdvisorByIdQueryResponse
            { 
                Response= new ResponseModel
                {
                    IsSuccess = true,
                    Message= "Successful",
                    Data= advisor,
                    StatusCode=200
                }

            };
              
        }
    }
}
