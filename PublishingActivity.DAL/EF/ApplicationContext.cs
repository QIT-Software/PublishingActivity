using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PublishingActivity.DAL.Entities;

namespace PublishingActivity.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public ApplicationContext() : base("DefaultConnection") { }

        static ApplicationContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<ProfessorProfile> ProfessorProfiles { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<PublicationStatusTracker> PublicationStatusTrackers { get; set; }
    }
}
