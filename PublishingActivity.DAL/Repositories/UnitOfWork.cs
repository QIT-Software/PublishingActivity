using PublishingActivity.DAL.EF;
using PublishingActivity.DAL.Entities;
using PublishingActivity.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Common;
using System.Threading.Tasks;
using PublishingActivity.DAL.Identity;

namespace PublishingActivity.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContext;

        public UnitOfWork(string connectionString)
        {
            _dbContext = new ApplicationContext(connectionString);
        }
        public ApplicationUserManager UserManager => new ApplicationUserManager(new UserStore<ApplicationUser>(_dbContext));
        public ApplicationRoleManager RoleManager => new ApplicationRoleManager(new RoleStore<ApplicationRole>(_dbContext));
        public IClientManager ClientManager => new ClientManager(_dbContext);
        public IRepository<Publication> PublicationRepository => new GenericRepository<Publication>(_dbContext);
        public IRepository<PublicationStatusTracker> PublicationStatusTrackerRepository => new GenericRepository<PublicationStatusTracker>(_dbContext);

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbException ex)
            {
                //logger.log(ex.)
            }

        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}