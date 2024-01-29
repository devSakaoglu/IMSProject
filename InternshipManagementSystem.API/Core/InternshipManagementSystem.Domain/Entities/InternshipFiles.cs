namespace InternshipManagementSystem.Domain.Entities
{
   public class InternshipFiles : BaseEntity
   {
      public InternAppAcceptForm? Form { get; set; }
      public InternshipApplicationInfoForAdviserExcel? Excel { get; set; }
      public InternshipBook? InternshipBook { get; set; }
      public SPAS? SPAS { get; set; }
      public AttendanceSchedule? AttendanceSchedule { get; set; }
      public WeeklyWorkPlan? WeeklyWorkPlan { get; set; }
      public ICollection<InternshipDocument>? OtherFiles { get; set; }
   }
}