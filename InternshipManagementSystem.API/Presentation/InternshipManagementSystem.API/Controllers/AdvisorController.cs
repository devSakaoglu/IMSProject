using InternshipManagementSystem.API.Constants;
using InternshipManagementSystem.Application.Features.Advisor.Commands.CreateAdvisor;
using InternshipManagementSystem.Application.Features.Advisor.Commands.DeleteAdvisorById;
using InternshipManagementSystem.Application.Features.Advisor.Commands.UpdateAdvisor;
using InternshipManagementSystem.Application.Features.Advisor.Queries.GetAdvisorById;
using InternshipManagementSystem.Application.Features.Advisor.Queries.GetAllAdvisor;
using InternshipManagementSystem.Application.Features.Advisor.Queries.GetStudentsOfAllAdvisors;
using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.AdvisorViewModels;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        readonly private IAdvisorReadRepository _advisorReadRepository;
        readonly private IAdvisorWriteRepository _advisorWriteRepository;
        readonly private IStudentReadRepository _studentReadRepository;
        readonly private IStudentWriteRepository _studentWriteRepository;
        readonly private IMediator _mediator;

        public AdvisorController(IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository, IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, IMediator mediator)
        {
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _mediator = mediator;
        }
        //[Authorize(Roles =UserType.Advisor)]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdvisorById(GetAdvisorByIdQueryRequest request)
        {
           GetAdvisorByIdQueryResponse response= await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllAdvisorQueryRequest request)
        {
            GetAllAdvisorQueryResponse response= await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStudentsOfAllAdvisors(GetStudentsOfAllAdvisorsQueryRequest request)
        {
           GetStudentsOfAllAdvisorsQueryResponse response= await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetStudentsOfAdvisor(GetStudentsOfAllAdvisorsQueryRequest request)
        {
            GetStudentsOfAllAdvisorsQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvisorCommandRequest request)
        {
            CreateAdvisorCommandResponse response= await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdvisor(UpdateAdvisorCommandRequest request)
        {
            UpdateAdvisorCommandResponse response = await _mediator.Send(request);
            return Ok(response);
           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisorById(DeleteAdvisorByIdCommandRequest request)
        {
            DeleteAdvisorByIdCommandResponse response= await _mediator.Send(request);
            return Ok(response);

        }




    }
}
