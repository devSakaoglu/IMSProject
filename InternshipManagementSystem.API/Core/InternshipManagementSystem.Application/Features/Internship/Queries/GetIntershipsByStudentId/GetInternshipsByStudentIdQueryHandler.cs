using InternshipManagementSystem.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InternshipManagementSystem.Application.Features.Internship
{
    public class GetInternshipsByStudentIdQueryHandler : IRequestHandler<GetInternshipsByStudentIdQueryRequest, GetInternshipsByStudentIdQueryResponse>
    {
        private readonly IInternshipReadRepository _internshipReadRepository;
        private readonly IInternshipApplicationFormReadRepository _internshipApplicationFormReadRepository;
        private readonly IInternshipApplicationExcelFormReadRepository _internshipApplicationExcelFormReadRepository;


        public GetInternshipsByStudentIdQueryHandler(IInternshipReadRepository internshipReadRepository, IInternshipApplicationFormReadRepository internshipApplicationFormReadRepository)
        {
            _internshipReadRepository = internshipReadRepository;
            _internshipApplicationFormReadRepository = internshipApplicationFormReadRepository;
        }

        public async Task<GetInternshipsByStudentIdQueryResponse> Handle(GetInternshipsByStudentIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<internshipAndExcel> internshipsExcelList = new List<internshipAndExcel>();

            var internshipssList = _internshipReadRepository.GetAll()
                .Where(x => x.StudentID == request.StudentId).ToList();
            foreach (var item in internshipssList)
            {
                var excelForm = await _internshipApplicationExcelFormReadRepository.GetByIdAsync(Guid.Parse(item.InternshipApplicationExelFormID.ToString()));

                internshipsExcelList.Add(new internshipAndExcel
                {
                    Internship = item,
                    InternshipApplicationExcelForm = excelForm
                });




                if (internshipsExcelList == null || internshipsExcelList.IsNullOrEmpty())
                {


                    return new GetInternshipsByStudentIdQueryResponse
                    {
                        Response = new()
                        {
                            Data = null,
                            Message = "Interships not found",
                            IsSuccess = false,
                            StatusCode = 404
                        }
                    };
                }
                else
                {
                    return new GetInternshipsByStudentIdQueryResponse
                    {
                        Response = new()
                        {
                            Data = internshipsExcelList,
                            Message = "Interships found",
                            IsSuccess = true,
                            StatusCode = 200
                        }
                    };


                }
                return new GetInternshipsByStudentIdQueryResponse
                {
                    Response = new()
                    {
                        Data = internshipsExcelList,
                        Message = "Interships found",
                        IsSuccess = true,
                        StatusCode = 200
                    }
                };

            }
        }
        public class internshipAndExcel
        {
            public InternshipManagementSystem.Domain.Entities.Internship Internship { get; set; }
            public InternshipManagementSystem.Domain.Entities.InternshipApplicationExcelForm InternshipApplicationExcelForm { get; set; }

        }
    }
}
