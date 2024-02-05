using InternshipManagementSystem.Application.Features.Commands.AppUser.CreateUser;
using InternshipManagementSystem.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
            public  UsersController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
          CreateUserCommandRequestResponse response =await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest  loginUserCommandRequest)
        {
            var isSignedIn = HttpContext.User.Identity.IsAuthenticated;
            LoginUserCommandResponse response= await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
        


    }
}
