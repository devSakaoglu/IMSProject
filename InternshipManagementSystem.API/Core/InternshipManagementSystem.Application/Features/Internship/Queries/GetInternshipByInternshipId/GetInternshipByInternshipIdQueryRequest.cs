using MediatR;

namespace InternshipManagementSystem.Application.Features.Internship.Queries.GetInternshipByInternshipId
{
    internal class GetInternshipByInternshipIdQueryRequest : IRequest<GetInternshipByInternshipIdQueryResponse>
    {
        public Guid? InternshipId { get; set; }
    }
}