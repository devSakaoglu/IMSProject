using InternshipManagementSystem.Application.DTO;
using InternshipManagementSystem.Application.Exceptions;
using InternshipManagementSystem.Application.Token;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        

        readonly ITokenHandler _tokenHandler;
        readonly UserManager<Domain.Entities.Identity.AppUser> _usermanager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signinmanager;
        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> usermanager, SignInManager<Domain.Entities.Identity.AppUser> signinmanager, ITokenHandler tokenHandler)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _tokenHandler = tokenHandler;

        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _usermanager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new NotFoundUserException("Kullanıcı adı veya şifre hatalı");
            }

        //SignInResult result = await _signinmanager.CheckPasswordSignInAsync(user, request.Password, false);
        
        
            var result = await _usermanager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                await _signinmanager.SignInAsync(user, true);
                DTO.Token token = _tokenHandler.CreateAccesstoken(5);
                return new LoginUserSuccessCommandResponse() { Token = token };
            }

            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Öğrenci no veya şifre hatalı"
            //};
            throw new AuthenticationErrorException();
        }
    }
}
