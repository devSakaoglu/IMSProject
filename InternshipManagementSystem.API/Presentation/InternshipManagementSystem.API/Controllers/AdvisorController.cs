using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels.AdvisorViewModels;
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
        public async Task<IActionResult> Get(string id)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(id, false);
            return Ok(advisor);

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = _advisorReadRepository.GetAll(false);
            return Ok(data);

        }

        [HttpPost]
        public async Task Post(VM_Create_Advisor model)
        {
            await _advisorWriteRepository.AddAsync(new()
            {
                TC_No = model.TC_No,
                Email = model.Email,
                Address = model.Address,
                AdvisorName = model.AdvisorName,
                AdviserSurname = model.AdviserSurname,
                DepartmentName = model.DepartmentName,
                FacultyName = model.FacultyName,
                ProgramName = model.ProgramName,
                Students = []
            });
            await _advisorWriteRepository.SaveAsync();

        }
        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Advisor model)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(model.ID.ToString());
            advisor.TC_No = model.TC_No;
            advisor.Email = model.Email;
            advisor.Address = model.Address;
            advisor.AdvisorName = model.AdvisorName;
            advisor.AdviserSurname = model.AdviserSurname;
            advisor.DepartmentName = model.DepartmentName;
            advisor.FacultyName = model.FacultyName;
            advisor.ProgramName = model.ProgramName;
            await _advisorWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _advisorWriteRepository.RemoveAsync(id);
            await _advisorWriteRepository.SaveAsync();
            return Ok();
        }




    }
}
