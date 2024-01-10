using İnternshipManagementSystem.Application.Repositories;
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

        [HttpGet("{id}")]
        public async Task Get()
        {


        }



    [HttpGet("/GetAll")]

    public IActionResult GetAll()
    {
        var data = _advisorReadRepository.GetAll();
        return Ok(data);

    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var advisor = await _advisorReadRepository.GetByIdAsync(id);
        return Ok(advisor);

    }

}
}
