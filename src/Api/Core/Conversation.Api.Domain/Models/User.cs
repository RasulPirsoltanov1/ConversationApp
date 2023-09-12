namespace Conversation.Api.Domain.Models
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress{ get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public bool EmailConfirmed{ get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
        public ICollection<EntryFavorite> EntryFavorites { get; set; }
        public ICollection<EntryComment> EntriesComments { get; set; }
        public ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }

    }
}