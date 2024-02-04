using System;

namespace InternshipManagementSystem.Domain.Entities
{

    public class Internship : BaseEntity
    {
        public Guid AdvisorID { get; set; }
        public Guid StudentID { get; set; }
        public InternshipStatus? Status { get; set; }
        public InternshipFiles? InternshipFiles { get; set; }

        public List<string>? StudentNotifications { get; set; }
        public List<string>? AdvisorNotifications { get; set; }



    }



}