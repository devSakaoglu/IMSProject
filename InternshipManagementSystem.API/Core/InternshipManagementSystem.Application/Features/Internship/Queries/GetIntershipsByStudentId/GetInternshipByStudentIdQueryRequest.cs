using MediatR;

namespace InternshipManagementSystem.Application.Features.Internship.Queries.GetIntershipsByStudentId
{
    public class GetInternshipsByStudentIdQueryRequest : IRequest<GetInternshipsByStudentIdQueryResponse>
    {
        public Guid? StudentId { get; set; }
    }
}