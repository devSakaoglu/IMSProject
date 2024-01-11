using InternshipManagementSystem.Domain.Entities;

namespace InternshipManagementSystem.Application.Abstractions
{
    public interface IStudentService
    {
        List<Student> GetStudents();
    }
}
