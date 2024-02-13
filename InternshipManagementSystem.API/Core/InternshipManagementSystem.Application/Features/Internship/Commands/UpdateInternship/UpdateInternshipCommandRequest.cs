using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Internship.Commands.UpdateInternship
{
    public class UpdateInternshipCommandRequest : IRequest<UpdateInternshipCommandResponse>
    {
        public Guid InternshipID { get; set; }
        public Guid? AdvisorID { get; set; }
        public string? StudentNo { get; set; }
        public Guid? StudentID { get; set; }
        public Guid? FormID { get; set; }
        public Guid? ExcelID { get; set; }
        public Guid? InternshipBookID { get; set; }
        public Guid? SPASID { get; set; }
        public Guid? AttendanceScheduleID { get; set; }
        public Guid? WeeklyWorkPlanID { get; set; }
    }
}
