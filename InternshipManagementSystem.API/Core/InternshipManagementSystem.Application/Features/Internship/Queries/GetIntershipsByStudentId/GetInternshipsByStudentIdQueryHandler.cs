using InternshipManagementSystem.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InternshipManagementSystem.Application.Features.Internship
{
    public class GetInternshipsByStudentIdQueryHandler : IRequestHandler<GetInternshipsByStudentIdQueryRequest, GetInternshipsByStudentIdQueryResponse>
    {
        IInternshipReadRepository _internshipReadRepository;
        IInternshipApplicationFormReadRepository _internshipApplicationFormReadRepository;

        public GetInternshipsByStudentIdQueryHandler(IInternshipReadRepository internshipReadRepository, IInternshipApplicationFormReadRepository internshipApplicationFormReadRepository)
        {
            _internshipReadRepository = internshipReadRepository;
            _internshipApplicationFormReadRepository = internshipApplicationFormReadRepository;
        }

        public Task<GetInternshipsByStudentIdQueryResponse> Handle(GetInternshipsByStudentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var internships = _internshipReadRepository.Table.Where(x => x.StudentID == request.StudentId);
            var excelForms = _internshipApplicationFormReadRepository.Table.ToList();

            var internshipsWithExcelForms = internships
    .Join(
        excelForms,
        internship => internship.InternshipApplicationExelFormID,
        excelForm => excelForm.ID,
        (internship, excelForm) => new
        {
            Internship = internship,
            ExcelForm = excelForm
        })


    .ToList();
   
            if (internships == null || internships.IsNullOrEmpty())
            {
                return Task.FromResult(new GetInternshipsByStudentIdQueryResponse
                {
                    Response = new()
                    {
                        Data = null,
                        Message = "No interships found",
                        IsSuccess = false,
                        StatusCode = 404
                    }
                });
            }
            else
            {
                return Task.FromResult(new GetInternshipsByStudentIdQueryResponse
                {
                    Response = new()
                    {
                        Data = internshipsWithExcelForms,
                        Message = "Interships found",
                        IsSuccess = true,
                        StatusCode = 200
                    }
                });

            }
        }
    }
}
