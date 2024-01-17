namespace InternshipManagementSystem.Domain.Entities
{

    public class Internship : BaseEntity
    {
        public Guid AdvisorID { get; set; }
        public Guid StudentID { get; set; }
        public InternshipStatus Status { get; set; }
        private InternAppAcceptForm Form { get; set; }
        private InternshipApplicationInfoForAdviserExcel Excel { get; set; }
        //public InternshipDocument InternshipBook { get; set; }
        //public InternshipDocument SPAS { get; set; }
        //public InternshipDocument AttendanceSchedule { get; set; }
        //public InternshipDocument WeeklyWorkPlan { get; set; }
        //public ICollection<InternshipDocument> OtherFiles { get; set; }


    }



}