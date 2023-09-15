using Conversation.Common.ViewModels.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Users
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(l=>l.Password).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(l=>l.EmailAddress).EmailAddress().NotEmpty().NotNull().MinimumLength(6).MaximumLength(50);
        }
    }
}
