namespace SuggestionSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public  sealed class Configuration : DbMigrationsConfiguration<SuggestionSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}
