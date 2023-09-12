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
    public class EntryCommentEntityConfiguration:BaseEntityConfiguration<EntryComment>
    {
        public override void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            builder.ToTable("entrycomment", ConversationDbContext.DEFAULT_SCHEME);
            builder.HasOne(x=>x.Entry).WithMany(e=>e.EntryComments).HasForeignKey(e=>e.EntryId);
            builder.HasOne(x => x.CreateBy).WithMany(u => u.EntriesComments).HasForeignKey(x=>x.CreateById).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }


  
}
