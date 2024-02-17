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
        public async Task<ExcelFormCommandResponse> Handle(ExcelFormCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
