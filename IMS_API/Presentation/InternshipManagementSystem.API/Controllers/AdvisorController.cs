using İnternshipManagementSystem.Application.Repositories;
using İnternshipManagementSystem.Domain.Entities;
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
            //   _advisorWriteRepository.AddAsyncRange(
            //       new()
            //       {
            //           new (){
            //               id= Guid.NewGuid(),
            //               AdviserName="Ali",
            //               AdviserSurname="Yılmaz",
            //               TC_ID="12345678910",
            //               DepartmentName="Bilgisayar Mühendisliği",
            //               AdviserGSMNumber    ="05321234567",
            //               Address="İstanbul",
            //               Email=""

            //           },
            //           new()
            //           {
            //               id= Guid.NewGuid(),
            //               AdviserName="Ayşe",
            //               AdviserSurname="Yılmaz",
            //               TC_ID="12345678910",
            //               DepartmentName="Bilgisayar Mühendisliği",
            //               AdviserGSMNumber    ="05321234567",
            //               Address="İstanbul",
            //               Email=""
            //           },
            //           new()
            //           {
            //               id = Guid.NewGuid(),
            //               AdviserName = "Ahmet",
            //               AdviserSurname = "Yılmaz",
            //               TC_ID = "12345678910",
            //               DepartmentName = "Bilgisayar Mühendisliği",
            //               AdviserGSMNumber = "05321234567",
            //               Address = "İstanbul",
            //               Email = ""
            //           }


            //       }

            //       );
            //var couınt =   await _advisorWriteRepository.SaveAsync();
            //
            //
            //Tracking testi
            ///
            ///

            //var e = await _advisorReadRepository.GetByIdAsync("659278ff-133f-4db9-b736-9d8aafc502cc",false);
            //e.AdviserGSMNumber = "05721234567";
            //await _advisorWriteRepository.SaveAsync();

        }

        [HttpGet("/GetA")]

        public async Task GetA()
        {
            await _advisorWriteRepository.AddAsyncRange(
                                 new()
                                 {
                    new()
                    {
                        id= Guid.NewGuid(),
                        AdviserID=Guid.NewGuid() .ToString (),
                        AdviserName="Alis",
                        AdviserSurname="Yılmaz",
                        TC_ID="12345678910",
                        DepartmentName="Bilgisayar Mühendisliği",
                        AdviserGSMNumber    ="05321234567",
                        Address="İstanbul",
                        Email="",

                    },
                    new()
                    {
                        id= Guid.NewGuid(),
                           AdviserID=Guid.NewGuid() .ToString (),
                        AdviserName="Ayşea",
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
                           AdviserID=Guid.NewGuid() .ToString (),
                        AdviserName = "Ahmetd",
                        AdviserSurname = "Yılmaz",
                        TC_ID = "12345678910",
                        DepartmentName = "Bilgisayar Mühendisliği",
                        AdviserGSMNumber = "05321234567",
                        Address = "İstanbul",
                        Email = ""
                    }
                                 });
            await _advisorWriteRepository.SaveAsync();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(id);
            return Ok(advisor);

        }

    }
}
