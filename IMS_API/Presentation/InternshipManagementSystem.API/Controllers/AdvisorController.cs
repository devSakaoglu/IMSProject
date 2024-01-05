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

        [HttpGet]
        public async Task Get()
        {
            _advisorWriteRepository.AddAsyncRange(
                new()
                {
                       new (){
                           id= Guid.NewGuid(),
                           AdviserID=Guid.NewGuid().ToString(),

                           AdviserName="Ali",
                           AdviserSurname="Yılmaz",
                           TC_ID="12345678910",
                           DepartmentName="Bilgisayar Mühendisliği",
                           AdviserGSMNumber    ="05321234567",
                           Address="İstanbul",
                           Email=""

                       },
                       new()
                       {
                           id= Guid.NewGuid(),
                                                  AdviserID=Guid.NewGuid().ToString(),


                           AdviserName="Ayşe",
                           AdviserSurname="Yılmaz",
                           TC_ID="12345678910",
                           DepartmentName="Bilgisayar Mühendisliği",
                           AdviserGSMNumber    ="05321234567",
                           Address="İstanbul",
                           Email=""
                       },
                       new()
                       {
                           id = Guid.NewGuid(),
                           AdviserID=Guid.NewGuid().ToString(),
                           AdviserName = "Ahmet",
                           AdviserSurname = "Yılmaz",
                           TC_ID = "12345678910",
                           DepartmentName = "Bilgisayar Mühendisliği",
                           AdviserGSMNumber = "05321234567",
                           Address = "İstanbul",
                           Email = ""
                       }


                }

                ); ;
            var couınt = await _advisorWriteRepository.SaveAsync();

            //
            //Tracking testi
            ///
            ///

            //var e = await _advisorReadRepository.GetByIdAsync("659278ff-133f-4db9-b736-9d8aafc502cc",false);
            //e.AdviserGSMNumber = "05721234567";
            //await _advisorWriteRepository.SaveAsync();

        }

        [HttpGet("/GetAll")]

        public  IActionResult GetAll()
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
