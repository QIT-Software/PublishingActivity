using PublishingActivity.DAL.Identity;
using System;
using System.Threading.Tasks;
using PublishingActivity.DAL.Entities;

namespace PublishingActivity.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        IRepository<Publication> PublicationRepository { get; }
        IRepository<PublicationStatusTracker> PublicationStatusTrackerRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
