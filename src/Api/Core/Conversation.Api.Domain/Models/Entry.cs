using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Domain.Models
{
    public class Entry : BaseEntity
    {
        public string Content { get; set; }
        public string Subject { get; set; }

        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        public virtual ICollection<EntryComment> EntryComments { get; set; }
        public virtual ICollection<EntryVote> EntryVotes { get; set; }
        public virtual ICollection<EntryFavorite> EntryFavorites { get; set; }
    }
}
