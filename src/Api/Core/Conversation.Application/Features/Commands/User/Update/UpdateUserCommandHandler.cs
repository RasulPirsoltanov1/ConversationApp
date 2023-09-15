using AutoMapper;
using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Common.Events;
using Conversation.Common.Infrastructure;
using Conversation.Common;
using Conversation.Common.Infrastructure.Exceptions;
using Conversation.Common.ViewModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Conversation.Api.Application.Features.Commands.Users.Update
{
    public class UpdateUserCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.GetByIdAsync(request.Id);
            if (existUser == null)
            {
                throw new DataBaseValidationException("user not found!");
            }
            var dbEmailAddress = existUser.EmailAddress;
            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;
            _mapper.Map(request, existUser);
            var rows = await _userRepository.UpdateAsync(existUser);
            //emailb 
            if (request.EmailAddress != existUser.EmailAddress)
            {

            }
            if (rows > 0 && emailChanged)
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
                existUser.EmailConfirmed = false;
                await _userRepository.UpdateAsync(existUser);
            }
            return existUser.Id;
        }
    }
}
