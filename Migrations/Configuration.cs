namespace CmsShoppingCart.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CmsShoppingCart.Models.Data.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CmsShoppingCart.Models.Data.Db";
        }

        protected override void Seed(CmsShoppingCart.Models.Data.Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
