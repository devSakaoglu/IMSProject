using İnternshipManagementSystem.Application.Abstractions;
using İnternshipManagementSystem.Domain.Entities;
namespace InternshipManagementSystem.Persistence.Concretes
{
    internal class StudentService : IStudentService
    {
        public List<Student> GetStudents()
        => new()
        {
            new Student()
            {
               id = Guid.NewGuid(),
            Address = "Address",
            AdviserID = "AdviserID",
            DepartmentName = "DepartmentName",
            Email = "Email",
            GPA = 1,
            ProgramName = "ProgramName",
            StudentGSMNumber = "StudentGSMNumber",
            StudentID =  Guid.NewGuid() .ToString (),
            StudentName = "StudentName",
            StudentSurname = "StudentSurname",
            TC_ID = "TC_ID"
            },    new Student()
            {
               id = Guid.NewGuid(),
            Address = "Address",
            AdviserID = "AdviserID",
            DepartmentName = "DepartmentName",
            Email = "Email",
            GPA = 1,
            ProgramName = "ProgramName",
            StudentGSMNumber = "StudentGSMNumber",
                     StudentID =  Guid.NewGuid() .ToString (),
            StudentName = "StudentName",
            StudentSurname = "StudentSurname",
            TC_ID = "TC_ID"
            },    new Student()
            {
               id = Guid.NewGuid(),
            Address = "Address",
            AdviserID = "AdviserID",
            DepartmentName = "DepartmentName",
            Email = "Email",
            GPA = 1,
            ProgramName = "ProgramName",
            StudentGSMNumber = "StudentGSMNumber",
                        StudentID =  Guid.NewGuid() .ToString (),

            StudentName = "StudentName",
            StudentSurname = "StudentSurname",
            TC_ID = "TC_ID"
            },    new Student()
            {
               id = Guid.NewGuid(),
            Address = "Address",
            AdviserID = "AdviserID",
            DepartmentName = "DepartmentName",
            Email = "Email",
            GPA = 1,
            ProgramName = "ProgramName",
            StudentGSMNumber = "StudentGSMNumber",
                                         StudentID = Guid.NewGuid() .ToString (),
            StudentName = "StudentName",
            StudentSurname = "StudentSurname",
            TC_ID = "TC_ID"
            },    new Student()
            {
                id = Guid.NewGuid(),
                Address = "Address",
                AdviserID = "AdviserID",
                DepartmentName = "DepartmentName",
                Email = "Email",
                GPA = 1,
                ProgramName = "ProgramName",
                StudentGSMNumber = "StudentGSMNumber",
                StudentID =  Guid.NewGuid() .ToString (),
                StudentName = "StudentName",
                StudentSurname = "StudentSurname",
                TC_ID = "TC_ID"
            },
        };
    }
}
