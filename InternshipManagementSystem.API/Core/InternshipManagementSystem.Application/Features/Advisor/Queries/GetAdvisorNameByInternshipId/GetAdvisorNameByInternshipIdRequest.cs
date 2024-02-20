using MediatR;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetAdvisorNameByInternshipId
{
    public class GetAdvisorNameByInternshipIdRequest : IRequest<GetAdvisorNameByInternshipIdResponse>
    {
      public  Guid StudentId { get; set; }
    }
}