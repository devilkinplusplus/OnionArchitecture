﻿using Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.User.Create
{
    public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
    {
        public CreateUserVM CreateUserVM { get; set; }
    }
}
