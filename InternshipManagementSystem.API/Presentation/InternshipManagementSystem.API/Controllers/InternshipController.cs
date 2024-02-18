using InternshipManagementSystem.Application.Features.Internship;
using InternshipManagementSystem.Application.Features.Internship.Commands;
using InternshipManagementSystem.Application.Features.Internship.Commands.CreateInternship;
using InternshipManagementSystem.Application.Features.Internship.Commands.ExelForm;
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
        private readonly IAdvisorReadRepository _advisorReadRepository;
        private readonly IInternshipReadRepository _internshipReadRepository;
        private readonly IInternshipWriteRepository _internshipWriteRepository;
        private readonly IInternshipDocumentReadRepository _internshipDocumentReadRepository;
        private readonly IInternshipDocumentWriteRepository _internshipDocumentWriteRepository;
        private readonly IFileService _fileService;
        private readonly IMediator _mediator;
        private readonly IInternshipApplicationFormReadRepository _internshipApplicationFormReadRepository;
        private readonly IInternshipBookReadRepository _internshipBookReadRepository;
        private readonly IInternshipApplicationExcelFormReadRepository _internshipApplicationExcelFormReadRepository;
        public InternshipController(IStudentReadRepository studentReadRepository, IAdvisorReadRepository advisorReadRepository, IInternshipReadRepository internshipReadRepository, IInternshipWriteRepository internshipWriteRepository, IInternshipDocumentReadRepository internshipDocumentReadRepository, IInternshipDocumentWriteRepository internshipDocumentWriteRepository, IFileService fileService, IMediator mediator
, IInternshipApplicationFormReadRepository internshipApplicationFormReadRepository, IInternshipBookReadRepository internshipBookReadRepository, IInternshipApplicationExcelFormReadRepository internshipApplicationExcelFormReadRepository)
        {
            _studentReadRepository = studentReadRepository;
            _advisorReadRepository = advisorReadRepository;
            _internshipReadRepository = internshipReadRepository;
            _internshipWriteRepository = internshipWriteRepository;
            _internshipDocumentReadRepository = internshipDocumentReadRepository;
            _internshipDocumentWriteRepository = internshipDocumentWriteRepository;
            _fileService = fileService;
            _mediator = mediator;
            _internshipApplicationFormReadRepository = internshipApplicationFormReadRepository;
            _internshipBookReadRepository = internshipBookReadRepository;
            _internshipApplicationExcelFormReadRepository = internshipApplicationExcelFormReadRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllInternships()
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
        public async Task<IActionResult> CreateInternship(CreateInternshipCommandRequest createInternshipCommandRequest)
        {
            CreateInternshipCommandResponse response = await _mediator.Send(createInternshipCommandRequest);
            return Ok(response.Response);


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
                    InternshipApplicationFormID = model.FormID,
                    InternshipApplicationExelFormID = model.ExcelID,
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

        //[HttpPost("[action]")]
        //public async Task<IActionResult> UploadDocument([FromForm] IFormFileCollection file, string StudentID, string InternshipID)
        //{

        //    var data = await _fileService.UploadAsync($"Students\\{StudentID}\\{InternshipID}", file, StudentID, InternshipID);
        //    return Ok(new ResponseModel()
        //    {
        //        Data = data.ToDictionary(),//null check ok check
        //        IsSuccess = data == null ? false : true,
        //        Message = data == null ? "Some Problems" : "Successful",
        //        StatusCode = data == null ? 404 : 200
        //    });
        //}

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
            var data = _internshipDocumentReadRepository.GetWhere(x => x.InternshipID == internshipId, false);
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetInternshipExcelForm([FromQuery]Guid internshipId)
        {
            var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
            if (internship == null)
            {
                return BadRequest(
                 new ResponseModel()
                 {
                     Data = null,
                     IsSuccess = false,
                     Message = "Internship Not Found",
                     StatusCode = 404
                 }
                 );
            }
            try
            {
                var excelForm =internship.InternshipApplicationExelFormID == null ? null : await _internshipApplicationExcelFormReadRepository.GetByIdAsync(internship.InternshipApplicationExelFormID.Value);
                return Ok(new ResponseModel()
                {
                    Data = excelForm,
                    IsSuccess = excelForm == null ? false : true,
                    Message = excelForm == null ? "Excel Form Not Found" : "Excel Form Found",
                    StatusCode = excelForm == null ? 404 : 200
                });



            }
            catch (Exception exexption)
            {

                return BadRequest(new ResponseModel()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = exexption.Message,
                    StatusCode = 400
                });
            }

        }



        [HttpPost("[action]")]
        public async Task<IActionResult> InternshipBook([FromForm] IFormFileCollection files, Guid internshipId)
        {
            var file = files.FirstOrDefault();
            var data = await _fileService.UploadAsync(internshipId, file, filetypes.InternshipBook);

            return Ok(new ResponseModel()
            {
                Message = data ? "Successful" : "Unsuccessful",
                Data = data,
                IsSuccess = data ? true : false,
                StatusCode = data ? 200 : 400
            });
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadApplicationForm([FromForm] IFormFileCollection files, Guid internshipId)
        {
            var file = files.FirstOrDefault();
            var data = await _fileService.UploadAsync(internshipId, file, filetypes.InternshipApplicationForm);

            return Ok(new ResponseModel()
            {
                Message = data ? "Successful" : "Unsuccessful",
                Data = data,
                IsSuccess = data ? true : false,
                StatusCode = data ? 200 : 400
            });
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetInternshipBookByInternshipId(Guid internshipId)
        {
            var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
            if (internship == null)
            {
                return NotFound();
            }

            var file = await _internshipBookReadRepository.GetByIdAsync(Guid.Parse(internship.InternshipBookID.ToString()));
            if (file is null)
            {
                return NotFound(
                    new ResponseModel()
                    {
                        Data = string.Empty,
                        IsSuccess= false,
                        Message="File is not found",
                        StatusCode=400
                    }
                    );
            }

            string filePath = Path.Combine(file.FilePath);

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", file.FileName);
            }
            else
            {
                return Ok(filePath);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetApplicationFormByInternshipId(Guid internshipId)
        {
            var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
            if (internship == null)
            {
                return NotFound();
            }

            var file = await _internshipApplicationFormReadRepository.GetByIdAsync(Guid.Parse(internship.InternshipApplicationFormID.ToString()));
            //string directoryPath = await _fileService.GetPath(internshipId);
            string filePath = Path.Combine(file.FilePath);

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", file.FileName);
            }
            else
            {

                return Ok(filePath);
            }
        }

    }

    //[HttpPost("[action]")]

    //public async Task<ExcelFormCommandResponse> ExcelForm(ExcelFormCommandRequest request)
    //{
    //    ExcelFormCommandResponse response = await _mediator.Send(request);
    //    return response;
    //}


}
