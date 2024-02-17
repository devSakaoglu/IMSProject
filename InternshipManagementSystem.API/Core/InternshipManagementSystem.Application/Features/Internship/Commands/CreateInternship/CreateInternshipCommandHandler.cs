using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Internship.Commands.CreateInternship
{
    public class CreateInternshipCommandHandler : IRequestHandler<CreateInternshipCommandRequest, CreateInternshipCommandResponse>
    {
        readonly IStudentReadRepository _studentReadRepository;
        readonly IAdvisorReadRepository _advisorReadRepository;
        readonly IInternshipWriteRepository _internshipWriteRepository;
        public async Task<CreateInternshipCommandResponse> Handle(CreateInternshipCommandRequest request, CancellationToken cancellationToken)
        {
            
            var student = _studentReadRepository.GetWhere(x => x.StudentNo == request.StudentNo).Include(x => x.Internships).FirstOrDefault();
            var advisor = await _advisorReadRepository.GetSingleAsync(x => x.ID == request.AdvisorID);
            if (student == null || advisor == null)
            {
                return (new CreateInternshipCommandResponse
                {
                    Response = new()
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Student or Advisor Not Found",
                        StatusCode = 404
                    }
                   
                });
            }
            try
            {
                var internship = new InternshipManagementSystem.Domain.Entities.Internship()
                {
                    StudentNo = student.StudentNo,
                    AdvisorID = request.AdvisorID,
                    StudentID = student.ID,  
                    InternshipStatus = InternshipStatus.Pending,
                    StudentName = student.StudentName,
                    StudentSurname = student.StudentSurname,
                };

                var st = await _internshipWriteRepository.AddAsync(internship);
                student.Internships.Add(internship);
                await _internshipWriteRepository.SaveAsync();
                return (new CreateInternshipCommandResponse
                {
                    Response = new()
                    {
                        Data = internship,
                        IsSuccess = true,
                        Message = "Internship Created",
                        StatusCode = 200
                    }
                   
                });
            }
            catch (Exception ex)
            {
                return (new CreateInternshipCommandResponse
                {
                    Response = new() {
                        Data = null,
                        IsSuccess = false,
                        Message = ex.Message,
                        StatusCode = 500
                    }
                    
                });

            }

        }
    }
}
