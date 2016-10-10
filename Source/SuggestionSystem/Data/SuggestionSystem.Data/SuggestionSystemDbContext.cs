namespace SuggestionSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class SuggestionSystemDbContext : IdentityDbContext<User>, ISuggestionSystemDbContext
    {
        public SuggestionSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public virtual IDbSet<Suggestion> Suggestions { get; set; }

        public static SuggestionSystemDbContext Create()
        {
            return new SuggestionSystemDbContext();
        }
    }
}
