using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.EntityConfigurations
{
    public class EmailConfirmationEntityConfiguration:BaseEntityConfiguration<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            builder.ToTable("emailconfirmation",ConversationDbContext.DEFAULT_SCHEME);
            base.Configure(builder);
        }
    }
}
