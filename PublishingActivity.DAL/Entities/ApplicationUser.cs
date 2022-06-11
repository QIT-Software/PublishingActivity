using Microsoft.AspNet.Identity.EntityFramework;

namespace PublishingActivity.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ProfessorProfile ProfessorProfile { get; set; }
    }
}