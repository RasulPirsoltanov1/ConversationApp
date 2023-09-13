using Bogus;
using Bogus.DataSets;
using Conversation.Api.Domain.Models;
using Conversation.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.Context
{
    internal class SeedData
    {
        public static List<User> GetUsers()
        {
            var result = new Faker<User>("az").RuleFor(x => x.Id, x => Guid.NewGuid())
                .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(100)))
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.EmailAddress, x => x.Internet.Email())
                .RuleFor(x => x.Username, x => x.Internet.UserName())
                .RuleFor(x => x.Password, x =>PasswordEncryptor.Encrypt(x.Internet.Password()))
                .RuleFor(x => x.EmailConfirmed, x => x.PickRandom(true,false))
                .Generate(500);
            return result;
        }

        public async Task SeedDataAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

            var context =new ConversationDbContext(dbContextBuilder.Options);
            if (context.Users.Any())
            {
                await Task.CompletedTask;
            }

            List<User> users = GetUsers();
            var userIds = users.Select(x=>x.Id);

            await context.Users.AddRangeAsync(users);

            var guids = Enumerable.Range(0, 150).Select(x => Guid.NewGuid()).ToList();
            int counter = 0;
            var entries = new Faker<Entry>("az").RuleFor(x => x.Id, x => guids[counter++])
                .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(100)))
                .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
                .RuleFor(x => x.Subject, x => x.Lorem.Sentence(5, 5))
                .RuleFor(x => x.CreatedById, x => x.PickRandom(userIds))
                .Generate(150);

            await context.Entrys.AddRangeAsync(entries);
            var commentIds=Enumerable.Range(1,230).Select(x=>Guid.NewGuid()).ToList();
            var comments = new Faker<EntryComment>("az").RuleFor(x => x.Id, x => Guid.NewGuid())
                 .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(100)))
                 .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
                 .RuleFor(x => x.CreateById, x => x.PickRandom(userIds))
                 .RuleFor(x => x.EntryId, x => x.PickRandom(guids))
                 .Generate(1000);
            await context.EntryComments.AddRangeAsync(comments);
            await context.SaveChangesAsync();
        }
    }
}
