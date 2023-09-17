using Conversation.Common;
using Conversation.Common.Events.EntryComment;
using Conversation.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class EntryCommentCreateFavCommandHandler : IRequestHandler<EntryCommentCreateFavCommand, bool>
    {
        public Task<bool> Handle(EntryCommentCreateFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessage(exchangeName: ConversationConstants.FavExchangeName,
                exchangeType: ConversationConstants.DefaultExchangeType,
                queueName: ConversationConstants.CreateEntryCommentFavQueueName,
                obj: new CreateEntryCommentFavEvent()
                {
                    EntryCommentId = request.EntryCommentId,
                    CreatedBy = request.UserId,
                });
            return Task.FromResult(true);
        }
    }
}
