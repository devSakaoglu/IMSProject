﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Queries.GetAdvisorById
{
    public class GetAdvisorByIdQueryRequest : IRequest<GetAdvisorByIdQueryResponse>
    {
        public Guid Id { get; set; }

    }
}
