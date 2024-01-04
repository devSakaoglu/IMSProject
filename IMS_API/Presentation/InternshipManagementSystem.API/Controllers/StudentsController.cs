using İnternshipManagementSystem.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;

        public StudentsController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _studentReadRepository.GetAll();
            return Ok();
        }
        [HttpGet("/get")]
        public IActionResult Get()
        {
            _studentWriteRepository.AddAsyncRange(
                               new()
                               {
                    new()
                    {
                        id= Guid.NewGuid(),
                        StudentID=Guid.NewGuid() .ToString (),
                        StudentName="Ali",
                        StudentSurname="Yılmaz",
                        TC_ID="12345678910",
                        DepartmentName="Bilgisayar Mühendisliği",
                        StudentGSMNumber    ="05321234567",
                        Address="İstanbul",
                        Email=""

                    },
                    new()
                    {
                        id= Guid.NewGuid(),
                        StudentID=Guid.NewGuid() .ToString (),
                        StudentName="Ayşe",
                        StudentSurname="Yılmaz",
                        TC_ID="12345678910",
                        DepartmentName="Bilgisayar Mühendisliği",
                        StudentGSMNumber    ="05321234567",
                        Address="İstanbul",
                        Email=""
                    },
                    new()
                    {
                        id = Guid.NewGuid(),
                        StudentID=Guid.NewGuid() .ToString (),
                        StudentName = "Ahmet",
                        StudentSurname = "Yılmaz",
                        TC_ID = "12345678910",
                        DepartmentName = "Bilgisayar Mühendisliği",
                        StudentGSMNumber = "05321234567",
                        Address = "İstanbul",
                        Email = ""
                    }
                               });
            var count = _studentWriteRepository.SaveAsync().Result;
            return Ok(count);
        }   

    }
}
