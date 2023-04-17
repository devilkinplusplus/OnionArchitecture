using Application.Features.Command.User.Create;
using Application.ViewModels.User;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateUserAsync(CreateUserVM model);
        Task UpdateRefreshTokenAsync(string refreshToken,User user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
