using Conversation.Common.ViewModels;

namespace Conversation.Api.Domain.Models
{
    public class EntryFavorite:BaseEntity
    {
        public Guid EntryId { get; set; }
        public virtual Entry Entry { get; set; }
        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}