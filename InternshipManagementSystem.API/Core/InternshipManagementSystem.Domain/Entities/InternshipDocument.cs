namespace InternshipManagementSystem.Domain.Entities
{
   public class InternshipDocument : BaseEntity
   {
      public Internship? Internship { get; set; }
      public string FileName { get; set; }
      public string FileType { get; set; }
   }
}

