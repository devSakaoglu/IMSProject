﻿using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Application.ViewModels.AdvisorViewModels;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var advisor = await _advisorReadRepository.GetByIdAsync(id, false);
            return Ok(
               new ResponseModel(true, "Successful", advisor, 200)
               );

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = _advisorReadRepository.GetAll(false);
            return Ok(
            new ResponseModel(true, "Successful", data, 200)
         );
        }
        [HttpPost]
        //Todo Post metthodu student icine yazilacak
        public async Task<IActionResult> Post(VM_Create_Advisor model)
        {
            Advisor e = _advisorReadRepository.GetSingleAsync(x => x.TC_NO == model.TC_NO, false).Result;
            if (e is not null)
            {
                var str = e.TC_NO == model.TC_NO ? "Student Number" : "";
                return Ok(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = $"There is a student with same {str} number",
                    Data = null,
                    StatusCode = 400

                });

            }

            Advisor advisor = new()
            {
                Address = model.Address,
                Email = model.Email,
                AdvisorName = model.AdvisorName,
                AdviserSurname = model.AdviserSurname,
                TC_NO = model.TC_NO,
                DepartmentName = model.DepartmentName,
                ProgramName = model.ProgramName,
                FacultyName = model.FacultyName,
            };
            try
            {
                await _advisorWriteRepository.AddAsync(advisor);
                await _advisorWriteRepository.SaveAsync();
                return Ok(new ResponseModel()
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Data = advisor,
                    StatusCode = 200

                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null,
                    StatusCode = 400

                });
            }


            return Ok(new ResponseModel()
            {
                IsSuccess = false,
                Message = "Some problems",
                Data = null,
                StatusCode = 499

            });

        }


        [HttpPut]
        public async Task<IActionResult> Update(VM_Update_Advisor model)
        {

            var advisor = await _advisorReadRepository.GetByIdAsync(model.id.ToString());

            if (advisor is null)
            {
                return Ok(new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Advisor not found",
                    Data = null,
                    StatusCode = 400

                });
            }

            advisor.TC_NO = model.TC_NO;
            advisor.Email = model.Email;
            advisor.Address = model.Address;
            advisor.AdvisorName = model.AdvisorName;
            advisor.AdviserSurname = model.AdviserSurname;
            advisor.DepartmentName = model.DepartmentName;
            advisor.FacultyName = model.FacultyName;
            advisor.ProgramName = model.ProgramName;
            await _advisorWriteRepository.SaveAsync();
            return Ok(
               new ResponseModel(true, "Successful", advisor, 200)
               );
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _advisorWriteRepository.RemoveAsync(id);

            if (result)
            {
                await _advisorWriteRepository.SaveAsync();
                return Ok(new ResponseModel(true,
                                    "Successful",
                                    null,
                                    200));
            }
            return BadRequest(new ResponseModel(false, "Delete is not complete possible id value is not correct", null, 400));

        }




    }
}
