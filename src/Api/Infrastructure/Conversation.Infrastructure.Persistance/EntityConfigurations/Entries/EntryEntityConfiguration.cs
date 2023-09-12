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
    public class EntryEntityConfiguration:BaseEntityConfiguration<Entry>
    {
        public override void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("entry", ConversationDbContext.DEFAULT_SCHEME);
            builder.HasOne(x=>x.CreatedBy).WithMany(x=>x.Entries).HasForeignKey(x=>x.CreatedById);

            base.Configure(builder);
        }
    }
}
