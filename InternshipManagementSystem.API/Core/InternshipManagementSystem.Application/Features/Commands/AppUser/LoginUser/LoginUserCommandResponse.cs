using InternshipManagementSystem.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {

        public DTO.Token Token { get; set; }


    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse 
    {

        public string Message { get; set; }



    }



}
