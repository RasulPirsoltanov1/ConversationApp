using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;

namespace Conversation.Infrastructure.Persistance.Repositories
{
    public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(ConversationDbContext context) : base(context)
        {
        }
    }




}
