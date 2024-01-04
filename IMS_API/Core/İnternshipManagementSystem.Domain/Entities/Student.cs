using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace İnternshipManagementSystem.Domain.Entities
{
    public class Student : BaseEntity
    {

        public string StudentID { get; set; }
        public string? AdviserID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? TC_ID { get; set; }
        public string? DepartmentName { get; set; }
        public string? ProgramName { get; set; }
        public float ?GPA { get; set; }
        public string? StudentGSMNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public ICollection<Internship>? Internships { get; set; }


    }

}
