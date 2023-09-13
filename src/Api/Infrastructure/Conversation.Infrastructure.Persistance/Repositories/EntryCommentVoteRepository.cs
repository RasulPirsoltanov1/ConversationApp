using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;

namespace Conversation.Infrastructure.Persistance.Repositories
{
    public class EntryCommentVoteRepository : GenericRepository<EntryCommentVote>, IEntryCommentVoteRepository
    {
        public EntryCommentVoteRepository(ConversationDbContext context) : base(context)
        {
        }
    }




}
