using Conversation.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.Context
{
    public class ConversationDbContext : DbContext
    {
     
        public ConversationDbContext()
        {
           
        }
        public ConversationDbContext(DbContextOptions options):base(options) { }
 
        public const string DEFAULT_SCHEME = "dbo";
        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entrys { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-UGCLLOE\\MSSQLSERVER2;Database=BlazorConversationDb;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        //Overrides




        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        public void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).Select(c => (BaseEntity)c.Entity);
            foreach (var entity in addedEntities)
            {
                if (entity.CreateDate == DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }

    }
}
