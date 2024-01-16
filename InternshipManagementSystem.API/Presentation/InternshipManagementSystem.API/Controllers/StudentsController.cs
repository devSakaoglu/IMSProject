using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels.StuentViewModels;
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
         var x=   _studentReadRepository.GetAll();
            return Ok(x);
        }
        [HttpGet("/AddRange")]
        public IActionResult AddRange()
        {
           
            var count = _studentWriteRepository.SaveAsync().Result;
            return Ok(count);
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Student model)
        {
            var x = await _studentWriteRepository.AddAsync(new()
            {
                    
                Address = model.Address,
                Email = model.Email,
                GPA = model.GPA,
                StudentGSMNumber = model.StudentGSMNumber,
                StudentName = model.StudentName,
                StudentNo = model.StudentNo,
                StudentSurname = model.StudentSurname,
                TC_ID = model.TC_ID,
                DepartmentName = model.DepartmentName,
                ProgramName = model.ProgramName


            });
            return Ok();
        }
    }
}
