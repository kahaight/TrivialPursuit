namespace TrivialPursuit.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrivialPursuitMVC.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TrivialPursuitMVC.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TrivialPursuitMVC.Data.ApplicationDbContext";
        }

        protected override void Seed(TrivialPursuitMVC.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()));
            for (int i = 0; i < 4; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("User{0}", i.ToString())
                };
                manager.Create(user, string.Format("Password{0}", i.ToString()));
            }
        }
    }
}
