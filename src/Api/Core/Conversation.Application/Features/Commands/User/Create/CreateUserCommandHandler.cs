using AutoMapper;
using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Common;
using Conversation.Common.Events;
using Conversation.Common.Infrastructure;
using Conversation.Common.Infrastructure.Exceptions;
using Conversation.Common.ViewModels.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.GetSingleAsync(u => u.EmailAddress == request.EmailAddress);
            if (existUser != null)
            {
                throw new DataBaseValidationException("this email has been registered already!");
            }
            var dbUser = _mapper.Map<User>(request);
            var rows = await _userRepository.AddAsync(dbUser);

            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    NewEmailAddress = request.EmailAddress,
                    OldEmailAddress = null
                };
                QueueFactory.SendMessage(exchangeName: ConversationConstants.UserExchangeName,
                    exchangeType: ConversationConstants.DefaultExchangeType,
                    queueName: ConversationConstants.UserEmailExchangedQueueName,
                    obj: @event
                    );
            }
            //emailb 
            return dbUser.Id;
        }
    }
}
