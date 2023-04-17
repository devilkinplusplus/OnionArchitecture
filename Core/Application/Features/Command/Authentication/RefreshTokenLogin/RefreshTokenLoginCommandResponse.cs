using Application.DTOs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.Authentication.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse : BaseCommandResponse
    {
        public Token Token { get; set; }
    }
}
