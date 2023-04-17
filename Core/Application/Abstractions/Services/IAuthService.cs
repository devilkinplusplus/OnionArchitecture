using Application.DTOs.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<DTOs.Tokens.Token> LoginAsync(string usernameOrEmail, string password);
        Task<DTOs.Tokens.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
