using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.ViewModels.StudentViewModels
{
    public class VM_Create_Student
    {
        public string StudentNo { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string TC_ID { get; set; }
        public string DepartmentName { get; set; }
        public string ProgramNameName { get; set; }
        public float GPA { get; set; }
        public string StudentGSMNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
