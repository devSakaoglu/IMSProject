using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetAdvisorNameByInternshipId
{
    public class GetAdvisorNameByInternshipIdHandler : IRequestHandler<GetAdvisorNameByInternshipIdRequest, GetAdvisorNameByInternshipIdResponse>
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IAdvisorReadRepository _advisorReadRepository;

        public GetAdvisorNameByInternshipIdHandler(IStudentReadRepository studentReadRepository, IAdvisorReadRepository advisorReadRepository)
        {
            _studentReadRepository = studentReadRepository;
            _advisorReadRepository = advisorReadRepository;
        }

        public async Task<GetAdvisorNameByInternshipIdResponse> Handle(GetAdvisorNameByInternshipIdRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var check = await _studentReadRepository.GetSingleAsync(x => x.ID == request.StudentId);
                var advisor =  await _advisorReadRepository.GetSingleAsync(x => x.ID == check.AdvisorID);
                var advisorName = advisor.AdvisorName.Trim() + " " + advisor.AdvisorSurname.Trim();
                return new GetAdvisorNameByInternshipIdResponse
                {
                    Response = new ResponseModel
                    {
                        Data = advisorName,
                        IsSuccess = true,
                        Message = "Success",
                        StatusCode = 200
                    }
                };

            }
            catch (Exception ex)
            {
                return new GetAdvisorNameByInternshipIdResponse
                {
                    Response = new ResponseModel
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = ex.Message,
                        StatusCode = 400
                    }
                };
            }


        }
    }
}
