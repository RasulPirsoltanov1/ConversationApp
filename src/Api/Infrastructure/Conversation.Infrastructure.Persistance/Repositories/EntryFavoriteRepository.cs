using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;

namespace Conversation.Infrastructure.Persistance.Repositories
{
    public class EntryFavoriteRepository : GenericRepository<EntryFavorite>, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(ConversationDbContext context) : base(context)
        {
        }
    }



}
