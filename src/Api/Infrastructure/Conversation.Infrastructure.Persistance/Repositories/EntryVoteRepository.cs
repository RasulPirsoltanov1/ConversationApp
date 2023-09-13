using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;

namespace Conversation.Infrastructure.Persistance.Repositories
{
    public class EntryVoteRepository : GenericRepository<EntryVote>, IEntryVoteRepository
    {
        public EntryVoteRepository(ConversationDbContext context) : base(context)
        {
        }
    }
}
