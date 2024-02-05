using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.InternshipViewModelss;
using InternshipManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InternshipController : ControllerBase
    {

        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IAdvisorReadRepository _advisorReadRepository;
        private readonly IAdvisorWriteRepository _advisorWriteRepository;
        private readonly IInternshipReadRepository _internshipReadRepository;
        private readonly IInternshipWriteRepository _internshipWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;

        public InternshipController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IInternshipReadRepository internshipReadRepository, IInternshipWriteRepository internshipWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
            _internshipReadRepository = internshipReadRepository;
            _internshipWriteRepository = internshipWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetInternships()
        {
            var data = _internshipReadRepository.GetAll();
            return Ok(new ResponseModel()
            {
                Data = data,
                IsSuccess = data == null ? false : true,
                Message = data == null ? "No Internship Found" : "Internships Found",
                StatusCode = data == null ? 404 : 200

            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInternship(string id)
        {
            var data = await _internshipReadRepository.GetByIdAsync(id);

            return Ok(new ResponseModel()
            {
                Data = data,
                IsSuccess = data == null ? false : true,
                Message = data == null ? "No Internship Found" : "Internship Found",
                StatusCode = data == null ? 404 : 200
            }
            );
        }
        [HttpPost]
        public async Task<IActionResult> CreateInternship(InternshipCreateVM model)
        {
            var data = await _studentReadRepository.AnyAsync(x => x.StudentNo == model.StudentNo);
            var data2 = await _advisorReadRepository.AnyAsync(x => x.ID == model.AdvisorID);
            if (data == null || data2 == null)
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Student or Advisor Not Found",
                    StatusCode = 404
                });
            }
            try
            {
                var adata = _studentReadRepository.GetWhere(x => x.StudentNo == model.StudentNo, true).FirstOrDefault();
                var internship = new Internship()
                {
                    AdvisorID = model.AdvisorID,
                    StudentID = adata.ID,
                    InternshipStatus = InternshipStatus.ApplicationPending,
                    FormID = model.FormID,
                    ExcelID = model.ExcelID,
                };
                await _internshipWriteRepository.AddAsync(internship);
                _internshipWriteRepository.SaveAsync();
                return Ok(new ResponseModel()
                {
                    Data = internship,
                    IsSuccess = true,
                    Message = "Internship Created",
                    StatusCode = 200
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 500
                });

            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInternship(InternshipUpdateVM model)
        {
            //Todo test et
            var data = await _internshipReadRepository.GetByIdAsync(model.InternshipID.ToString());
            if (data is not null)
            {
                data = new Internship()
                {
                    FormID = model.FormID,
                    ExcelID = model.ExcelID,
                    InternshipBookID = model.InternshipBookID,
                    SPASID = model.SPASID,
                    AttendanceScheduleID = model.AttendanceScheduleID,
                    WeeklyWorkPlanID = model.WeeklyWorkPlanID
                };
                await _internshipWriteRepository.SaveAsync(); return Ok(new ResponseModel()
                {
                    Data = data,
                    IsSuccess = true,
                    Message = "Internship Updated",
                    StatusCode = 200

                });
            }
            else
            {

                return Ok(new ResponseModel()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Internship Not Found",
                    StatusCode = 404
                });

            }



            return Ok("Internship Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternship(Guid id)
        {
            //Todo test et
            var result   = await _internshipWriteRepository.RemoveAsync(id.ToString());
            return Ok(new ResponseModel() {
            Data= result,
            IsSuccess=result == true ? true : false,    
            Message=result == true ? "Internship Deleted" : "Internship Not Found",
            StatusCode=result == true ? 200 : 404
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] IFormFileCollection file, string StudentID, string InternshipID )
        {
            var data = await _fileService.UploadAsync($"Students\\{StudentID}\\{InternshipID}", file,  StudentID,  InternshipID);
            return Ok(new ResponseModel()
            {
                Data = data.ToDictionary(),
                IsSuccess = data == null ? false : true,
                Message = data == null ? "Some Problems" : "Successful",
                StatusCode = data == null ? 404 : 200
            });

        }

        [HttpGet("download/{id}")]
        public IActionResult DownloadFile(string id)
        {
            return Ok("File Downloaded");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteFile(string id)
        {
            return Ok("File Deleted");
        }




    }
}
