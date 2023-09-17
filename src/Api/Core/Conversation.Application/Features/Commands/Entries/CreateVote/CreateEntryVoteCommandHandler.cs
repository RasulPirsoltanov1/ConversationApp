using Conversation.Common.Events.Entry;
using Conversation.Common;
using Conversation.Common.Infrastructure;
using Conversation.Common.ViewModels.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Entries.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {
        public Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessage(exchangeName: ConversationConstants.VoteExchangeName,
               exchangeType: ConversationConstants.DefaultExchangeType,
               queueName: ConversationConstants.CreateEntryVoteQueueName,
               obj: new CreateEntryVoteEvent()
               {
                   EntryId = request.EntryId,
                   CreateBy = request.CreateBy,
                   VoteType = request.VoteType,
               });
            return Task.FromResult(true);
        }
    }
}
