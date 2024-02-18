﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Commands.UpdateAdvisor
{
    public class UpdateAdvisorCommandRequest : IRequest<UpdateAdvisorCommandResponse>
    {
        public Guid AdvisorID { get; set; }
        public string AdvisorName { get; set; }
        public string AdviserSurname { get; set; }
        public string TC_NO { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public string ProgramName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
