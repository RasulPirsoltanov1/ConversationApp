using Conversation.Common.ViewModels;

namespace Conversation.Api.Domain.Models
{
    public class EntryCommentVote:BaseEntity
    {
        public Guid EntryCommentId { get; set; }
        public virtual EntryComment EntryComment { get; set; }
        public Guid CreatedById { get; set; }
        public virtual VoteType VoteType{ get; set; }
    }
}