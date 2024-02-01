namespace InternshipManagementSystem.Domain.Entities
{

   public class InternAppAcceptForm : BaseEntity
   {
      public Guid InternshipID { get; set; }

      public string StudentName { get; set; }
      public string StudentSurname { get; set; }
      public string TC_NO { get; set; }
      public bool SPAS { get; set; }
      public string CompanyName { get; set; }
      public string CompanyAddress { get; set; }
      public string FieldOfActivity { get; set; }
      public string GSMNumber { get; set; }
      public string ManagerEmail { get; set; }
      public string ManagerFullName { get; set; }
      public string ManagerPosition { get; set; }
      public string StartDatePlan { get; set; }
      public string EndDatePlan { get; set; }
      public bool IsPaid { get; set; }
      public double Price { get; set; }
      public string Days { get; set; }


   }

}