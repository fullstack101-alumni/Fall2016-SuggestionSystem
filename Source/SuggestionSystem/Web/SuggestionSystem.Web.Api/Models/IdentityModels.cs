using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace SuggestionSystem.Web.Api.Models
{
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