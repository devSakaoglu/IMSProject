
namespace InternshipManagementSystem.Domain.Entities
{
   public class InternshipApplicationInfoForAdviserExcel : BaseEntity
   {
      public Internship internship { get; set; }

      public string StudentNo { get; set; }
      public string FullName { get; set; }
      public string TC_NO { get; set; }
      public string InternshipStartDate { get; set; }
      public string InternshipEndDate { get; set; }
      public string Department { get; set; }
      public string InternshipType { get; set; }
      public string StudentGSMNumber { get; set; }
      public string CompanyName { get; set; }
      public int NumberOfEmployees { get; set; }
      public string CompanyPhone { get; set; }
      public string CompanyAddress { get; set; }
      public double RequestedGovernmentAidAmount { get; set; }
      public bool ReceivesSalary { get; set; }
      public bool DoesNotReceiveSalary { get; set; }
      public bool Gender { get; set; }
      public int Age { get; set; }
      public bool ReceivesHealthInsurance { get; set; }
      public int BirthDateDay { get; set; }
      public int BirthDateMonth { get; set; }
      public int BirthDateYear { get; set; }
      public string EmailSendingDate { get; set; }
      public InternshipLevel? Level { get; set; }
      public string Description { get; set; }

   }
}