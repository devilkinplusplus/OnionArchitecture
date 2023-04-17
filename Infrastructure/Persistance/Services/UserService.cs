using Application.Abstractions.Services;
using Application.Features.Command.User.Create;
using Application.Validators;
using Application.ViewModels.User;
using AutoMapper;
using Domain.Entities.Identity;
using Domain.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public UserService(UserManager<User> userManager, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserVM model)
        {
            CreateUserCommandResponse response = new();
            User user = _mapper.Map<User>(model);

            UserValidator validations = new();
            ValidationResult results = validations.Validate(user);

            if(await HasEmail(model.Email))
            {
                response.Succeeded = false;
                response.Errors = new List<string>()
                {
                    "Email is already exist"
                }; 
                return response;
            }
            else if (results.IsValid)
            {
                IdentityResult identityResult = await _userManager.CreateAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,
                }, model.Password);

                response.Succeeded = identityResult.Succeeded;
                response.Errors = identityResult.Errors.Select(x => x.Description);
            }
            response.Succeeded = results.IsValid;
            response.Errors = results.Errors.Select(x => x.ErrorMessage);

            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user is not null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(45);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new UserNotFoundException();
        }

        private async Task<bool> HasEmail(string email) => await _context.Users.AnyAsync(x => x.Email == email);

    }
}
