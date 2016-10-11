namespace SuggestionSystem.Data.Migrations
{
    using System.Linq;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Common.Constants;

    public  sealed class Configuration : DbMigrationsConfiguration<SuggestionSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SuggestionSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var user = new IdentityRole { Name = UserConstants.UserRole };
                var admin = new IdentityRole { Name = UserConstants.AdminRole };
                
                manager.Create(user);
                manager.Create(admin);
            }
        }
    }
}