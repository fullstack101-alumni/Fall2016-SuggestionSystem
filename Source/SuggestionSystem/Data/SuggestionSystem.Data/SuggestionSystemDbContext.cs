namespace SuggestionSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class SuggestionSystemDbContext : IdentityDbContext<User>
    {
        public SuggestionSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SuggestionSystemDbContext Create()
        {
            return new SuggestionSystemDbContext();
        }
    }
}
