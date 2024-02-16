using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace InternshipManagementSystem.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
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
        public TestController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IInternshipReadRepository internshipReadRepository, IInternshipWriteRepository internshipWriteRepository, IInternshipDocumentReadRepository internshipDocumentReadRepository, IInternshipDocumentWriteRepository internshipDocumentWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService, IMediator mediator, IInternshipApplicationFormReadRepository internshipApplicationFormReadRepository, IInternshipApplicationFormWriteRepository internshipApplicationFormWriteRepository, IInternshipBookReadRepository internshipBookReadRepository, IInternshipBookWriteRepository internshipBookWriteRepository)
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


        [HttpPost]
        public async Task<IActionResult> Test()
        {
            return Ok("Test");
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
        [HttpPost("[action]")]
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
