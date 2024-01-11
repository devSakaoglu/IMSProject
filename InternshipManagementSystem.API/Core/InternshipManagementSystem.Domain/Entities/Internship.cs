namespace InternshipManagementSystem.Domain.Entities
{

    public class Internship : BaseEntity
    {
        public Guid AdvisorID { get; set; }
        public Guid StudentID { get; set; }
        public InternshipStatus Status { get; set; }
        private InternAppAcceptForm Form { get; set; }
        private InternshipApplicationInfoForAdviserExcel Excel { get; set; }
        //public FileData InternshipBook { get; set; }
        //public FileData SPAS { get; set; }
        //public FileData AttendanceSchedule { get; set; }
        //public FileData WeeklyWorkPlan { get; set; }
        //public ICollection<FileData> OtherFiles { get; set; }


    }



}