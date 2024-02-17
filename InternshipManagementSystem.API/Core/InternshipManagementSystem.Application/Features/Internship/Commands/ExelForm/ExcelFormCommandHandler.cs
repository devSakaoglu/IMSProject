using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Repositories.InternshipApplicationExcelForm;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Internship.Commands.ExelForm
{
    public class ExcelFormCommandHandler : IRequestHandler<ExcelFormCommandRequest, ExcelFormCommandResponse>
    {
        readonly IInternshipApplicationExcelFormWriteRepository _internshipApplicationExcelFormWriteRepository;
        public async Task<ExcelFormCommandResponse> Handle(ExcelFormCommandRequest request, CancellationToken cancellationToken)
        {
            var ExcelForm = new InternshipApplicationExelForm()
            {
                StudentNo = request.StudentNo,
                FullName = request.FullName,
                TC_NO = request.TC_NO,
                InternshipStartDate = request.InternshipStartDate,
                InternshipEndDate = request.InternshipEndDate,
                Department = request.Department,
                InternshipType = request.InternshipType,
                StudentGSMNumber = request.StudentGSMNumber,
                CompanyName = request.CompanyName,
                NumberOfEmployees = request.NumberOfEmployees,
                CompanyPhone = request.CompanyPhone,
                CompanyAddress = request.CompanyAddress,
                RequestedGovernmentAidAmount = request.RequestedGovernmentAidAmount,
                ReceivesSalary = request.ReceivesSalary,
                DoesNotReceiveSalary = request.DoesNotReceiveSalary,
                 Gender =request.Gender,
                 Age =request.Age,
                 ReceivesHealthInsurance=request.ReceivesHealthInsurance,
                 BirthDateDay =request.BirthDateDay,
                 BirthDateMonth =request.BirthDateMonth,
                 EmailSendingDate =request.EmailSendingDate,
                  Level =request.Level,
                 Description =request.Description,  

                };
            await _internshipApplicationExcelFormWriteRepository.AddAsync(ExcelForm);
            
            return (new ExcelFormCommandResponse {
                Response = new()
                {
                    Data = null,
                    IsSuccess = true,
                    Message = "true",
                    StatusCode = 200
                }
            
            
            });
        }
    }
}
