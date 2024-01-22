using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.StudentViewModels;
using InternshipManagementSystem.Application.ViewModels.StuentViewModels;
using InternshipManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IAdvisorReadRepository _advisorReadRepository;
        private readonly IAdvisorWriteRepository _advisorWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentsController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()

        {
            var x = _studentReadRepository.GetAll();
            return Ok(x);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var advisor = await _studentReadRepository.GetByIdAsync(id, false);
            return Ok(advisor);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(VM_Create_Student model)
        {
            Student student = await _studentReadRepository.GetSingleAsync(x => x.TC_NO == model.TC_NO || x.StudentNo == model.StudentNo, false);
            if (student is null)
            {
                return Ok(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = $"There is not a student with these properties",
                    Data = null,
                    StatusCode = 400

                });

            }



            var advisor = await _advisorReadRepository.GetAll().Include(x => x.Students).FirstOrDefaultAsync(x => x.ID == model.AdvisorID);
            if (advisor != null)
            {
                try
                {
                    advisor.Students.Add(student);
                    await _advisorWriteRepository.SaveAsync();
                    await _studentWriteRepository.SaveAsync();
                    return Ok(new ResponseModel()
                    {
                        IsSuccess = true,
                        Message = "Successful",
                        Data = student,
                        StatusCode = 200

                    });
                }
                catch (Exception ex)
                {
                    return Ok(new ResponseModel()
                    {
                        IsSuccess = false,
                        Message = ex.Message,
                        Data = null,
                        StatusCode = 400

                    });
                }

            }
            return Ok(new ResponseModel()
            {
                IsSuccess = false,
                Message = "Some problems",
                Data = null,
                StatusCode = 499

            });
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Student model)
        {
            Student e = _studentReadRepository.GetFirst(x => x.TC_NO == model.TC_NO || x.StudentNo == model.StudentNo, false);
            if (e is not null)
            {
                var str = e.StudentNo == model.StudentNo ? "Student Number" : "TC Number";
                return Ok(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = $"There is a student with same {str} number",
                    Data = null,
                    StatusCode = 400

                });
            }
            await _studentWriteRepository.AddAsync(new Student()
            {
                Address = model.Address,
                Email = model.Email,
                GPA = model.GPA,
                StudentGSMNumber = model.StudentGSMNumber,
                StudentName = model.StudentName,
                StudentNo = model.StudentNo,
                StudentSurname = model.StudentSurname,
                TC_NO = model.TC_NO,
                DepartmentName = model.DepartmentName,
                ProgramName = model.ProgramName,
                FacultyName = model.FacultyName,
            });
            if (await _studentWriteRepository.SaveAsync() == 1)
            {
                return Ok(
                   new ResponseModel(true, "Student added", null, 200)

                   );

            }
            else
            {
                return Ok(
                       new ResponseModel(false, "Some problems", null, 400)
                                           );
            }




        }

        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Student model)
        {
            var student = await _studentReadRepository.GetByIdAsync(model.StudentID.ToString());

            if (student is null)
            {
                return Ok(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Student not found",
                    Data = null,
                    StatusCode = 400

                });
            }

            student.TC_NO = model.TC_NO;
            student.Email = model.Email;
            student.Address = model.Address;
            student.StudentName = model.StudentName;
            student.StudentSurname = model.StudentSurname;
            student.StudentNo = model.StudentNo;
            student.StudentGSMNumber = model.StudentGSMNumber;
            student.GPA = model.GPA;
            student.DepartmentName = model.DepartmentName;
            student.ProgramName = model.ProgramName;
            await _studentWriteRepository.SaveAsync();
            return Ok(
               new ResponseModel(true, "Succesful", student, 200)
               );
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _studentWriteRepository.RemoveAsync(id);
            await _studentWriteRepository.SaveAsync();
            return Ok(
                new
                {
                    Deletion_Process = "Successful",
                    StatusCode = 200
                });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var req = Request;
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "files");

            Guid guid = Guid.NewGuid();
            string fullPath = Path.Combine(uploadPath, $"{guid.ToString()}{file.FileName.Replace(" ", "_")}");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            try
            {
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return Ok("completed");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                await fileStream.FlushAsync();
                return Ok("not completed");

            }



            return Ok("Some Problems");

        }
    }
}
