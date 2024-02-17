using InternshipManagementSystem.Application.Features.Internship;
using InternshipManagementSystem.Application.Features.Internship.Commands;
using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.InternshipViewModelss;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly IInternshipDocumentReadRepository _internshipDocumentReadRepository;
        private readonly IInternshipDocumentWriteRepository _internshipDocumentWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IMediator _mediator;
        private readonly IInternshipApplicationFormReadRepository _internshipApplicationFormReadRepository;
        private readonly IInternshipApplicationFormWriteRepository _internshipApplicationFormWriteRepository;
        private readonly IInternshipBookReadRepository _internshipBookReadRepository;
        private readonly IInternshipBookWriteRepository _internshipBookWriteRepository;
        public InternshipController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IInternshipReadRepository internshipReadRepository, IInternshipWriteRepository internshipWriteRepository, IInternshipDocumentReadRepository internshipDocumentReadRepository, IInternshipDocumentWriteRepository internshipDocumentWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService, IMediator mediator
, IInternshipApplicationFormReadRepository internshipApplicationFormReadRepository, IInternshipApplicationFormWriteRepository internshipApplicationFormWriteRepository, IInternshipBookReadRepository internshipBookReadRepository, IInternshipBookWriteRepository internshipBookWriteRepository)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
            _internshipReadRepository = internshipReadRepository;
            _internshipWriteRepository = internshipWriteRepository;
            _internshipDocumentReadRepository = internshipDocumentReadRepository;
            _internshipDocumentWriteRepository = internshipDocumentWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _mediator = mediator;
            _internshipApplicationFormReadRepository = internshipApplicationFormReadRepository;
            _internshipApplicationFormWriteRepository = internshipApplicationFormWriteRepository;
            _internshipBookReadRepository = internshipBookReadRepository;
            _internshipBookWriteRepository = internshipBookWriteRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInternships( )
        {
            GetAllInternshipsQuery query = new GetAllInternshipsQuery();
            GetAllInternshipsQueryResponse response = await _mediator.Send(query);
            return Ok(response.Response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetInternshipByInternshipId(Guid id)
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetIntershipsByStudentId([FromQuery] GetInternshipsByStudentIdQueryRequest request)
        {
            GetInternshipsByStudentIdQueryResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetIntershipsAdvisorId([FromQuery] GetInternshipsByAdvisorIdQueryRequest request)
        {
            GetInternshipsByAdvisorIdQueryResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }



        [HttpPost]
        public async Task<IActionResult> CreateInternship(InternshipCreateVM model)
        {
            var student = _studentReadRepository.GetWhere(x => x.StudentNo == model.StudentNo).Include(x => x.Internships).FirstOrDefault();
            var advisor = await _advisorReadRepository.GetSingleAsync(x => x.ID == model.AdvisorID);
            if (student == null || advisor == null)
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
                var internship = new Internship();
                internship = new Internship()
                {
                    StudentNo = student.StudentNo,
                    AdvisorID = model.AdvisorID,
                    StudentID = student.ID,
                    InternshipStatus = InternshipStatus.Pending,
                    StudentName = student.StudentName,
                    StudentSurname = student.StudentSurname,
                };

                var st = await _internshipWriteRepository.AddAsync(internship);
                student.Internships.Add(internship);
                await _internshipWriteRepository.SaveAsync();
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
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInternship(InternshipUpdateVM model)
        {
            //Todo test et
            var data = await _internshipReadRepository.GetByIdAsync(model.InternshipID);
            if (data is not null)
            {
                data = new Internship()
                {
                    InternAppAcceptFormID = model.FormID,
                    InternshipApplicationInfoForAdviserExcelID = model.ExcelID,
                    InternshipBookID = model.InternshipBookID,
                    SPASID = model.SPASID,

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

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInternshipByInternshipStatus(UpdateInternshipByInternshipStatusCommandRequest request)
        {
            UpdateInternshipByInternshipStatusCommandResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteInternship(Guid id)
        {
            //Todo test et
            var result = await _internshipWriteRepository.RemoveAsync(id);
            await _internshipWriteRepository.SaveAsync();
            return Ok(new ResponseModel()
            {
                Data = result,
                IsSuccess = result == true ? true : false,
                Message = result == true ? "Internship Deleted" : "Internship Not Found",
                StatusCode = result == true ? 200 : 404
            });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadDocument([FromForm] IFormFileCollection file, string StudentID, string InternshipID)
        {

            var data = await _fileService.UploadAsync($"Students\\{StudentID}\\{InternshipID}", file, StudentID, InternshipID);
            return Ok(new ResponseModel()
            {
                Data = data.ToDictionary(),//null check ok check
                IsSuccess = data == null ? false : true,
                Message = data == null ? "Some Problems" : "Successful",
                StatusCode = data == null ? 404 : 200
            });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadBookFile(Guid bookId)
        {
            var data = await _internshipBookReadRepository.GetByIdAsync(bookId);
            if (data == null)
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "File Not Found",
                    StatusCode = 404
                });
            }
            else
            {
                var path = data.FilePath;
                return Ok(new ResponseModel()
                {
                    Data = path,
                    IsSuccess = path == null ? false : true,
                    Message = path == null ? "File Not Found" : "File Found",
                    StatusCode = path == null ? 404 : 200
                });
            }

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDocuments(Guid internshipId)
        {
            var data = _internshipReadRepository.GetAll().Where(x => x.ID == internshipId).Select(x => x.InternsipDocuments).ToList();
            return Ok(new ResponseModel()
            {
                Data = data,
                IsSuccess = data == null ? false : true,
                Message = data == null ? "No Document Found" : "Documents Found",
                StatusCode = data == null ? 404 : 200
            });
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
            var data = _internshipDocumentReadRepository.GetByIdAsync(id);
            if (data == null)
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "File Not Found",
                    StatusCode = 404
                });
            }
            else
            {

                if (await _fileService.DeleteFileAsync(data.Result.FilePath) == false)
                {
                    return Ok(new ResponseModel()
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "File Not Deleted",
                        StatusCode = 404
                    });
                }
                else
                {

                    _internshipDocumentWriteRepository.RemoveAsync(id);
                    return Ok(new ResponseModel()
                    {
                        Data = null,
                        IsSuccess = true,
                        Message = "File Deleted",
                        StatusCode = 200
                    });
                }

            }
        }





        [HttpPost("[action]")]
        public async Task<IActionResult> UploadBook([FromForm] IFormFileCollection files, Guid internshipId)
        {
            var file = files.FirstOrDefault();
            var data = await _fileService.UploadAync(internshipId, file, filetypes.InternshipBook);

            return Ok(new ResponseModel()
            {
                Message = data ? "Successful" : "Unsuccessful",
                Data = data,
                IsSuccess = data ? true : false,
                StatusCode = data ? 200 : 400
            });
        }
        [NonAction]
        public async Task<IActionResult> UploadApplicationForm([FromForm] IFormFileCollection files, Guid internshipId)
        {
            var file = files.FirstOrDefault();
            var data = await _fileService.UploadAync(internshipId, file, filetypes.InternshipApplicationForm);

            return Ok(new ResponseModel()
            {
                Message = data ? "Successful" : "Unsuccessful",
                Data = data,
                IsSuccess = data ? true : false,
                StatusCode = data ? 200 : 400
            });
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBookByInternshipId(Guid internshipId)
        {
            var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
            var data = _internshipDocumentReadRepository.GetFirst(x => x.ID == internship.InternshipBookID, false);

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Data = data,
                StatusCode = 200
            });
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetApplicationFormByInternshipId(Guid internshipId)
        {
            var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
            var data = _internshipApplicationFormReadRepository.GetFirst(x => x.ID == internship.InternAppAcceptFormID, false);

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Data = data,
                StatusCode = 200
            });
        }




    }
}
