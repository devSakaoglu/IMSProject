using InternshipManagementSystem.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.AppUser.Commands.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Guid UserID { get; set; }
        public  string? UserTypeName { get; set; }

    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }

    }

}
