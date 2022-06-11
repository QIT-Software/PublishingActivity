using PublishingActivity.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace PublishingActivity.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}