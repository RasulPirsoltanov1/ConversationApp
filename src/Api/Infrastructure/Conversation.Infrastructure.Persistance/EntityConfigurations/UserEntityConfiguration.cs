using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conversation.Infrastructure.Persistance.EntityConfigurations
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", ConversationDbContext.DEFAULT_SCHEME);
            base.Configure(builder);
        }
    }
}
