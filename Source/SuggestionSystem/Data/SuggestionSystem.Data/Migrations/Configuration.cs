namespace SuggestionSystem.Data.Migrations
{
    using System.Linq;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Common.Constants;
    using Models;

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

            if (!context.Users.Any(u => u.UserName == "hns150@aubg.edu"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                var admin = new User { Email = "hns150@aubg.edu", EmailConfirmed = true, UserName = "hns150@aubg.edu" };
                manager.CreateAsync(admin, "Hristo1!");

                var rolesToAdd = new string[] { "User", "Admin" };
                manager.AddToRolesAsync(admin.Id, rolesToAdd);
            }
        }
    }
}