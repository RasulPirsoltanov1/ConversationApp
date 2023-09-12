using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conversation.Infrastructure.Persistance.EntityConfigurations.EntryComments
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            builder.ToTable("entrycommentvote", ConversationDbContext.DEFAULT_SCHEME);
            builder.HasOne(x => x.EntryComment).WithMany(ec => ec.EntryCommentVotes).HasForeignKey(x => x.EntryCommentId);

            base.Configure(builder);
        }
    }
}
