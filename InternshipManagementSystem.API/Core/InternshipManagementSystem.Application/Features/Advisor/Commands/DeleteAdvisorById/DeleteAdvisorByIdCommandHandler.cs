using InternshipManagementSystem.Application.Repositories;
using InternshipManagementSystem.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Advisor.Commands.DeleteAdvisorById
{
    public class DeleteAdvisorByIdCommandHandler : IRequestHandler<DeleteAdvisorByIdCommandRequest, DeleteAdvisorByIdCommandResponse>
    {
        readonly IAdvisorReadRepository _advisorReadRepository;
        readonly IAdvisorWriteRepository _advisorWriteRepository;

        public DeleteAdvisorByIdCommandHandler(IAdvisorReadRepository advisorReadRepository, IAdvisorWriteRepository advisorWriteRepository)
        {
            _advisorReadRepository = advisorReadRepository;
            _advisorWriteRepository = advisorWriteRepository;
        }

        public async Task<DeleteAdvisorByIdCommandResponse> Handle(DeleteAdvisorByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var advisor = _advisorReadRepository.GetSingleAsync(x => x.ID == request.Id);

            if (advisor is null)
            {
                return new DeleteAdvisorByIdCommandResponse
                {
                    Response = new ResponseModel
                    {
                        IsSuccess = false,
                        Message = "Advisor not found",
                        Data = null,
                        StatusCode = 400
                    }
                };   
            }
            else
            {
                advisor.Result.Students.Clear();
            }

            if (await _advisorWriteRepository.RemoveAsync(request.Id))
            {
                await _advisorWriteRepository.SaveAsync();

                return new DeleteAdvisorByIdCommandResponse
                {
                    Response = new ResponseModel
                    {
                        IsSuccess = true,
                        Message = "Successfuly advisor deleted",
                        Data = null,
                        StatusCode = 200
                    }

                };   
            }
            else
            {
                return new DeleteAdvisorByIdCommandResponse
                {
                    Response = new ResponseModel
                    {
                        IsSuccess = false,
                        Message = "Delete is not complete possible id value is not correct",
                        Data = null,
                        StatusCode = 400
                    }

                };
            }

        }
    }
    
}
