namespace İnternshipManagementSystem.Domain.Entities
{

    public class Internship : BaseEntity
    {
        public string InternshipId { get; set; }
        public string AdviserID { get; set; }
        public string StudentID { get; set; }
        public InternshipStatus Status { get; set; }
        private InternAppAcceptForm Form { get; set; }
        private InternshipApplicationInfoForAdviserExcel Excel { get; set; }
        public FileData InternshipBook { get; set; }
        public FileData SPAS { get; set; }
        public FileData AttendanceSchedule { get; set; }
        public FileData WeeklyWorkPlan { get; set; }
        public ICollection<FileData> OtherFiles { get; set; }


    }



}