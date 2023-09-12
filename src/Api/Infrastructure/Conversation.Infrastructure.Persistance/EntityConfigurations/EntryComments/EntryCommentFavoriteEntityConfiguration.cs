using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.EntityConfigurations.EntryComments
{
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            builder.ToTable("entrycommentfavorite", ConversationDbContext.DEFAULT_SCHEME);
            builder.HasOne(x => x.EntryComment).WithMany(e => e.EntryCommentFavorites).HasForeignKey(e => e.EntryCommentId);
            builder.HasOne(x => x.CreatedBy).WithMany(u => u.EntryCommentFavorites).HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}
