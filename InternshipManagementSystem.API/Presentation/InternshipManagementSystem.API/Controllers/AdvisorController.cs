using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorController : ControllerBase
    {
        readonly private IAdvisorReadRepository _advisorReadRepository;
        readonly private IAdvisorWriteRepository _advisorWriteRepository;

        public AdvisorController(IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository)
        {
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
        }
        [HttpGet("id")]

        public async Task<IActionResult> Get(string id)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(id, false);
            return Ok(advisor);

        }

        [HttpPost("/Add")]
        public async Task Add(Advisor advisor)
        {
            var Advisor = advisor;

            await _advisorWriteRepository.AddAsync(Advisor);
            await _advisorWriteRepository.SaveAsync();

        }

        [HttpDelete("/Delete{id}")]
        public async Task Delete(string id)
        {
            await _advisorWriteRepository.RemoveAsync(id);
        }




        [HttpGet("/GetAll")]

        public IActionResult GetAll()
        {
            var data = _advisorReadRepository.GetAll();
            return Ok(data);

        }




    }
}
