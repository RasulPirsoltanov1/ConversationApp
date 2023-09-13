using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Infrastructure.Persistance.Context;
using Conversation.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConversationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            var seedData = new SeedData();

            seedData.SeedDataAsync(configuration).GetAwaiter().GetResult();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryCommentFavoriteRepository,EntryCommentFavoriteRepository>();
            services.AddScoped<IEntryCommentRepository,EntryCommentRepository>();
            services.AddScoped<IEntryCommentVoteRepository,EntryCommentVoteRepository>();
            services.AddScoped<IEntryVoteRepository,EntryVoteRepository>();
            services.AddScoped<IEntryFavoriteRepository,EntryFavoriteRepository>();
            services.AddScoped<IEmailConfirmationRepository,EmailConfirmationRepository>();




            return services;
        }
    }
}
