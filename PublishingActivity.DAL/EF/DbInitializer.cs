using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PublishingActivity.DAL.Entities;

namespace PublishingActivity.DAL.EF
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));

            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "user" };
            var role3 = new ApplicationRole { Name = "deleted" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}