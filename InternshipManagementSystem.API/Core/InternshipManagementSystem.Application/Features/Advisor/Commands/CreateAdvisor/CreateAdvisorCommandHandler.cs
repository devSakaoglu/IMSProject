using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Commands.CreateAdvisor
{
    public class CreateAdvisorCommandHandler : IRequestHandler<CreateAdvisorCommandRequest, CreateAdvisorCommandResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;
        readonly IAdvisorWriteRepository _advisorWriteRepository;

        public CreateAdvisorCommandHandler(IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository)
        {
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
        }

        public async Task<CreateAdvisorCommandResponse> Handle(CreateAdvisorCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Advisor e = await _advisorReadRepository.GetSingleAsync(x => x.TC_NO == request.TC_NO, false);
            if (e is not null)
            {
                var str = e.TC_NO == request.TC_NO ? "Student Number" : "";
                return new CreateAdvisorCommandResponse
                {
                    Response= new ResponseModel
                    {
                        IsSuccess = false,
                        Message = $"There is a student with same {str} number",
                        Data = null,
                        StatusCode = 400
                    }
                   

                };

            }

            Domain.Entities.Advisor advisor = new()
            {
                Address = request.Address,
                Email = request.Email,
                AdvisorName = request.AdvisorName,
                AdvisorSurname = request.AdviserSurname,
                TC_NO = request.TC_NO,
                DepartmentName = request.DepartmentName,
                ProgramName = request.ProgramName,
                FacultyName = request.FacultyName,
            };



            try
            {
                await _advisorWriteRepository.AddAsync(advisor);
                await _advisorWriteRepository.SaveAsync();
                return new CreateAdvisorCommandResponse
                {
                    Response=new ResponseModel {
                        IsSuccess = true,
                        Message = "Successful",
                        Data = advisor,
                        StatusCode = 200
                    }
                    
                };
            }
            catch (Exception ex)
            {
                return new CreateAdvisorCommandResponse
                {
                    Response= new ResponseModel
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                        Data = null,
                        StatusCode = 400
                    }
                   

                };
            }


            return new CreateAdvisorCommandResponse
            {
                Response= new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Some problems",
                    Data = null,
                    StatusCode = 499
                }
               

            };



        }
    }
}
