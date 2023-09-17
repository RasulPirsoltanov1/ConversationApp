using Conversation.Common;
using Conversation.Common.Events.Entry;
using Conversation.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Entries.CreateFav
{
    public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
    {
        public Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessage(exchangeName: ConversationConstants.FavExchangeName,
                exchangeType: ConversationConstants.DefaultExchangeType,
                queueName: ConversationConstants.CreateEntryFavQueueName,
                obj: new CreateEntryFavEvent()
                {
                    EntryId= request.EntryId,
                    CreateBy= request.UserId,
                });
            return Task.FromResult(true);
        }
    }
}
