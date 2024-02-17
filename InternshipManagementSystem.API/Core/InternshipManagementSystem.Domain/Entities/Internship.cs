using System;

namespace InternshipManagementSystem.Domain.Entities
{

    public class Internship : BaseEntity
    {


        public Guid AdvisorID { get; set; }
        public Guid StudentID { get; set; } 
        public string StudentNo { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        
       //todo extra bilgiler

        public List<InternshipDocument>?  InternsipDocuments { get; set; }

        public List<string>? StudentNotifications { get; set; }
        public List<string>? AdvisorNotifications { get; set; }
        //todo nullabe 
        public InternshipStatus InternshipStatus { get; set; }
        public Guid? InternAppAcceptFormID { get; set; }
        public Guid? InternshipApplicationInfoForAdviserExcelID { get; set; }
        public Guid? InternshipBookID { get; set; }
        public Guid? SPASID { get; set; }
      

      


    }



}