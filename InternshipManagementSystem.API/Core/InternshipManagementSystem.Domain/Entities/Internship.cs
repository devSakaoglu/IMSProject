using System;

namespace InternshipManagementSystem.Domain.Entities
{

    public class Internship : BaseEntity
    {


        public Guid AdvisorID { get; set; }
        public Guid StudentID { get; set; }
        public InternshipStatus? Status { get; set; }

        public List<string>? StudentNotifications { get; set; }
        public List<string>? AdvisorNotifications { get; set; }
        public InternshipStatus InternshipStatus { get; set; }
        public string StudentNo { get; set; }
        public Guid? FormID { get; set; }
        public Guid? ExcelID { get; set; }
        public Guid? InternshipBookID { get; set; }
        public Guid? SPASID { get; set; }
        public Guid? AttendanceScheduleID { get; set; }
        public Guid? WeeklyWorkPlanID { get; set; }
    }



}