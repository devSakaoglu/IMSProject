using InternshipManagementSystem.Application.Features.Internship;
using InternshipManagementSystem.Application.Features.Internship.Commands;
using InternshipManagementSystem.Application.Features.Internship.Commands.CreateInternship;
using InternshipManagementSystem.Application.Features.Internship.Commands.DeleteInternship;
using InternshipManagementSystem.Application.Features.Internship.Queries.GetInternshipByInternshipId;
using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.InternshipViewModelss;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetInternshipByInternshipId([FromQuery] GetInternshipByInternshipIdQueryRequest request)
        {
            GetInternshipByInternshipIdQueryResponse response = await _mediator.Send(request);
            return Ok();

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
        public async Task<IActionResult> CreateInternship(CreateInternshipCommandRequest request)
        {
            CreateInternshipCommandResponse response = await _mediator.Send(request);
            return Ok(response.Response);


        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInternship(UpdateInternshipByInternshipStatusCommandRequest request)
        {
            UpdateInternshipByInternshipStatusCommandResponse response = await _mediator.Send(request);
            return Ok(response.Response);
         
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateInternshipByInternshipStatus(UpdateInternshipByInternshipStatusCommandRequest request)
        {
            UpdateInternshipByInternshipStatusCommandResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }

        //
        //
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteInternship(DeleteInternshipCommandRequest request)
        {
            DeleteInternshipCommandResponse response = await _mediator.Send(request);
            return Ok(response.Response);
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
        //
        //

      

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadInternshipBook([FromForm] IFormFileCollection files, [FromForm] Guid internshipId)
        {
            var fileTest = HttpContext.Request.Form.Files.First();
            //var file = files.FirstOrDefault();
            var data = await _fileService.UploadAsync(internshipId, fileTest, filetypes.InternshipBook);

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
                        IsSuccess = false,
                        Message = "File is not found",
                        StatusCode = 400
                    }
                    );
            }
            string directoryPath = await _fileService.GetPath(internshipId);

            string filePath = Path.Combine(directoryPath, file.FileName);

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
            string directoryPath = await _fileService.GetPath(internshipId);
            string filePath = Path.Combine(directoryPath, file.FileName);

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
        public async Task<IActionResult> GetInternshipExcelForm([FromQuery] GetInternshipExcelFormQueryRequest request)
        {
            GetInternshipExcelFormQueryResponse response = await _mediator.Send(request);
            return Ok(response.Response);

        }
    }

}
