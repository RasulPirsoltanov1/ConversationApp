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
    public class EntryFavoriteEntityConfiguration:BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);
            builder.ToTable("entryfavorite", ConversationDbContext.DEFAULT_SCHEME);
            builder.HasOne(x=>x.Entry).WithMany(x=>x.EntryFavorites).HasForeignKey(x=>x.EntryId);
            builder.HasOne(x => x.CreatedBy).WithMany(u => u.EntryFavorites).HasForeignKey(x=>x.CreatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
