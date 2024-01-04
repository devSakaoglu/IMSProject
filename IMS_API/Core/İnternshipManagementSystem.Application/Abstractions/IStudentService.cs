using İnternshipManagementSystem.Domain.Entities;

namespace İnternshipManagementSystem.Application.Abstractions
{
    public interface IStudentService
    {
        List<Student> GetStudents();
    }
}
