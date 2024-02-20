using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetAllAdvisor
{
    public class GetAllAdvisorQueryHandler : IRequestHandler<GetAllAdvisorQueryRequest, GetAllAdvisorQueryResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;

        public GetAllAdvisorQueryHandler(IAdvisorReadRepository advisorReadRepository)
        {
            _advisorReadRepository = advisorReadRepository;
        }

        public async Task<GetAllAdvisorQueryResponse> Handle(GetAllAdvisorQueryRequest request, CancellationToken cancellationToken)
        {
            var data = _advisorReadRepository.GetAll(false);

            return new GetAllAdvisorQueryResponse
            {
                Response = new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Data = data,
                    StatusCode = 200


                }

            };


        }
    }
}
