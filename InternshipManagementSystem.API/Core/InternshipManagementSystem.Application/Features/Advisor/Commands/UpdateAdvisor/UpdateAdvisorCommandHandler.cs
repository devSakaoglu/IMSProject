using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Commands.UpdateAdvisor
{
    public class UpdateAdvisorCommandHandler : IRequestHandler<UpdateAdvisorCommandRequest, UpdateAdvisorCommandResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;
        readonly IAdvisorWriteRepository _advisorWriteRepository;

        public UpdateAdvisorCommandHandler(IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository)
        {
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
        }

        public async Task<UpdateAdvisorCommandResponse> Handle(UpdateAdvisorCommandRequest request, CancellationToken cancellationToken)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(request.AdvisorID);

            if (advisor is null)
            {
                return new UpdateAdvisorCommandResponse
                {
                    Response= new ResponseModel {
                        IsSuccess = false,
                        Message = "Advisor not found",
                        Data = null,
                        StatusCode = 400
                    }
                    

                };
            }

            advisor.TC_NO = request.TC_NO;
            advisor.Email = request.Email;
            advisor.Address = request.Address;
            advisor.AdvisorName = request.AdvisorName;
            advisor.AdvisorSurname = request.AdviserSurname;
            advisor.DepartmentName = request.DepartmentName;
            advisor.FacultyName = request.FacultyName;
            advisor.ProgramName = request.ProgramName;

            await _advisorWriteRepository.SaveAsync();
            return new UpdateAdvisorCommandResponse
            {
                Response = new ResponseModel
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Data = advisor,
                    StatusCode = 200
                }

            };
              
        }
    }
}
