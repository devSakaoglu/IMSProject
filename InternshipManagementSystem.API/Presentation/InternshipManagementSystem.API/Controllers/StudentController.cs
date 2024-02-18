using InternshipManagementSystem.Application.Features.Student;
using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.Services;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.StudentViewModels;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternshipManagementSystem.Application.Features;
using InternshipManagementSystem.Application.Features.Student.Commands.CreateStudent;
using InternshipManagementSystem.Application.Features.Student.Commands.AddStudentToAdvisor;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IAdvisorReadRepository _advisorReadRepository;
        private readonly IAdvisorWriteRepository _advisorWriteRepository;
        private readonly IMediator _mediator;

        public StudentController(IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService, IMediator mediator)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetStudentAllQueryResponse response = await _mediator.Send(new GetStudentAllQueryRequest());

            return Ok(response.Response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStudentById([FromQuery] GetStudentByIdQueryRequest request)
        {
            GetStudentByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response.Response);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStudentByUsername([FromQuery] GetStudentByUsernameQueryRequest request)
        {
            GetStudentByUsernameQueryResponse response = await _mediator.Send(request);
            return Ok(response.Response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStudentByAdvisorId([FromQuery] GetStudentByAdvisorIdQueryRequest request)
        {
            GetStudentByAdvisorIdQueryResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }


        //
        [HttpPost("[action]")]
        public async Task<IActionResult> AddToAdvisor(AddStudentToAdvisorRequest request)
        {
            //Student student = await _studentReadRepository.GetSingleAsync(s => s.ID == model.StudentID, true);
            //if (student is null)
            //{
            //    return Ok(new ResponseModel()
            //    {
            //        IsSuccess = false,
            //        Message = $"There is not a student with these properties",
            //        Data = null,
            //        StatusCode = 400

            //    });

            //}

            //var advisor = await _advisorReadRepository.GetAll().Include(a => a.Students).FirstOrDefaultAsync(x => x.ID == model.AdvisorID);
            //var ifStudentExists = advisor.Students.Any(student => student.ID == model.StudentID);
            //if (ifStudentExists)
            //{
            //    return Ok(new ResponseModel()
            //    {
            //        IsSuccess = false,
            //        Message = "Student already exists",
            //        Data = null,
            //        StatusCode = 400

            //    });
            //}
            //if (advisor != null)
            //{
            //    try
            //    {
            //        student.AdvisorID = advisor.ID;

            //        var y = await _studentWriteRepository.SaveAsync();
            //        var res = new ResponseModel()
            //        {
            //            IsSuccess = true,
            //            Message = "Successful",
            //            Data = student,
            //            StatusCode = 200

            //        };
            //        return Ok(res);


            //    }
            //    catch (Exception ex)
            //    {
            //        return Ok(new ResponseModel()
            //        {
            //            IsSuccess = false,
            //            Message = ex.Message,
            //            Data = null,
            //            StatusCode = 400

            //        });
            //    }

            //}
            //return Ok(new ResponseModel()
            //{
            //    IsSuccess = false,
            //    Message = "Some problems",
            //    Data = null,
            //    StatusCode = 499

            //});
            AddStudentToAdvisorResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }

        //
        [HttpPost]
        public async Task<IActionResult> Post(CreateStudentCommandRequest request)
        {
           
            CreateStudentCommandResponse response= await _mediator.Send(request);
            return Ok(response.Response);

        }
        //
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommandRequest request)
        {
            var student = await _studentReadRepository.GetByIdAsync(request.StudentID);

            if (student is not null)
            {
                UpdateStudentCommandResponse response = await _mediator.Send(request);
            }


            await _studentWriteRepository.SaveAsync();
            return Ok(
               new ResponseModel(true, "Succesful", student, 200)
               );
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteStudentByIdCommandRequest request)
        {
            DeleteStudentByIdCommandResponse response = await _mediator.Send(request);
            return Ok(response.Response);
        }



    }
}
