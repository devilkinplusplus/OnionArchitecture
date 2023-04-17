using Application.DTOs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.Authentication.Login
{
    public class LoginCommandResponse : BaseCommandResponse
    {
        public Token Token { get; set; }
    }
}
