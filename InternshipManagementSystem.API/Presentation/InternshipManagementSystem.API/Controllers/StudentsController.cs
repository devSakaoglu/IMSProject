using InternshipManagementSystem.Application.Repositories;
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

    }
}
