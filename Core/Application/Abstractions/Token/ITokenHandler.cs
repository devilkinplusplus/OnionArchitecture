using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Tokens.Token CreateAccessToken(User user);
        string CreateRefreshToken();
    }
}
