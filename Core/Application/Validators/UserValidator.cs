using Application.Consts;
using Domain.Entities.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage(ErrorMessages.EmptyNameMessage);
            RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(20).WithMessage(ErrorMessages.InvalidNameMessage);

            RuleFor(x => x.LastName).NotNull().WithMessage(ErrorMessages.EmptyLastNameMessage);
            RuleFor(x => x.LastName).MinimumLength(3).MaximumLength(35).WithMessage(ErrorMessages.InvalidLastNameMessage);

            RuleFor(x => x.Email).NotNull().WithMessage(ErrorMessages.EmptyEmailMessage);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessages.InvalidEmailMessage);

            RuleFor(x => x.UserName).NotNull().WithMessage(ErrorMessages.EmptyUsernameMessage);
            RuleFor(x=>x.UserName).MinimumLength(3).MaximumLength(16).WithMessage(ErrorMessages.InvalidUsernameMessage);
        }
    }
}
