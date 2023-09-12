using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.EntityConfigurations.Entries
{
    public class EntryVoteEntityConfiguration:BaseEntityConfiguration<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            builder.ToTable("entryvote", ConversationDbContext.DEFAULT_SCHEME);

            builder.HasOne(x=>x.Entry).WithMany(e=>e.EntryVotes).HasForeignKey(e=>e.EntryId).OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
