using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Common.Events.Users;
using Conversation.Common.Infrastructure;
using Conversation.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.User.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.Id.HasValue)
            {
                throw new ArgumentNullException(nameof(request.Id));
            }
            var dbUser=await _userRepository.GetByIdAsync(request.Id.Value);
            if(dbUser == null)
            {
                throw new ArgumentNullException(nameof(dbUser)); 
            }
            var encPas = PasswordEncryptor.Encrypt(request.OldPassword);
            if (dbUser.Password != encPas)
            {
                throw new DataBaseValidationException("old password is inccorrect!");
            }
            dbUser.Password = encPas;
            await _userRepository.UpdateAsync(dbUser);
            return true;
        }
    }
}
