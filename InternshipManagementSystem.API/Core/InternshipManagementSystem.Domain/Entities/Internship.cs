using System;

namespace InternshipManagementSystem.Domain.Entities
{

   public class Internship : BaseEntity
   {
      public Advisor? Advisor { get; set; }
      public Student? Student { get; set; }
      public InternshipStatus? Status { get; set; }
      public InternshipFiles? InternshipFiles { get; set; }


    }



}