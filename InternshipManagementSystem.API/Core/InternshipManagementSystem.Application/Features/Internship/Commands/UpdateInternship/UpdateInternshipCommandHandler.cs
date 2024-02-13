using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Internship.Commands.UpdateInternship
{
    public class UpdateInternshipCommandHandler : IRequestHandler<UpdateInternshipCommandRequest, UpdateInternshipCommandResponse>
    {
       

        public Task<UpdateInternshipCommandResponse> Handle(UpdateInternshipCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
