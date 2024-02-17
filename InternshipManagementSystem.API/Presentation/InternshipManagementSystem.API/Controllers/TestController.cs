using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Domain.Entities;
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

        [HttpGet("health")]
        public async Task<IActionResult> Health()
        {
            string user = "Anonymous";
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                user = HttpContext.User.Identity.Name;
            }
            var envConnectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DEFAULT");
            string currentDirectory = Directory.GetCurrentDirectory();



            return Ok($"Connection string health:{envConnectionString != null}, DB connection healthy:{_studentReadRepository != null} Logged in username is:{user} " +
                $"Directory : {currentDirectory}");
        }



        [HttpGet("[action]")]
        public async Task<IActionResult>DownloadBook(Guid InternshipId)
        {
            var x = await _internshipReadRepository.GetByIdAsync(InternshipId);
            if (x == null)
            {
                return NotFound();
            }

            var filename=  await _internshipDocumentReadRepository.GetByIdAsync(Guid.Parse(x.InternshipBookID.ToString())); 
            string directoryPath = await _fileService.GetPath(InternshipId);
            string filePath = Path.Combine(directoryPath, filename.FileName);

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", filename.FileName);
            }
            else
            {

                return Ok(filePath);
            }
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> UploadBook([FromForm] IFormFileCollection files, Guid internshipId)
        //{
        //    var file = files.FirstOrDefault();
        //    var data = await _fileService.UploadAync(internshipId, file, filetypes.InternshipBook);

        //    return Ok(new ResponseModel()
        //    {
        //        Message = data ? "Successful" : "Unsuccessful",
        //        Data = data,
        //        IsSuccess = data ? true : false,
        //        StatusCode = data ? 200 : 400
        //    });
        //}
        //[HttpPost("[action]")]
        //public async Task<IActionResult> UploadApplicationForm([FromForm] IFormFileCollection files, Guid internshipId)
        //{
        //    var file = files.FirstOrDefault();
        //    var data = await _fileService.UploadAync(internshipId, file, filetypes.InternshipApplicationForm);

        //    return Ok(new ResponseModel()
        //    {
        //        Message = data ? "Successful" : "Unsuccessful",
        //        Data = data,
        //        IsSuccess = data ? true : false,
        //        StatusCode = data ? 200 : 400
        //    });
        //}
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetBookByInternshipId(Guid internshipId)
        //{
        //    var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
        //    var data = _internshipDocumentReadRepository.GetFirst(x => x.ID == internship.InternshipBookID, false);

        //    return Ok(new ResponseModel()
        //    {
        //        IsSuccess = true,
        //        Data = data,
        //        StatusCode = 200
        //    });
        //}
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetApplicationFormByInternshipId(Guid internshipId)
        //{
        //    var internship = await _internshipReadRepository.GetByIdAsync(internshipId);
        //    var data = _internshipApplicationFormReadRepository.GetFirst(x => x.ID == internship.InternAppAcceptFormID, false);

        //    return Ok(new ResponseModel()
        //    {
        //        IsSuccess = true,
        //        Data = data,
        //        StatusCode = 200
        //    });
        //}



    }
}
