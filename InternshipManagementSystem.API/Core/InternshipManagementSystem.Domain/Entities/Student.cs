using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InternshipManagementSystem.Domain.Entities
{
    public class Student : BaseEntity
    {

        public string StudentNo { get; set; }
        public Guid AdvisorID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string TC_No { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public string ProgramNameName { get; set; }
        public float GPA { get; set; }
        public string StudentGSMNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<Internship> Internships { get; set; }


    }

}
