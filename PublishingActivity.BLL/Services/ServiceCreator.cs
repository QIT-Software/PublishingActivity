using PublishingActivity.BLL.Interfaces;
using PublishingActivity.DAL.Repositories;

namespace PublishingActivity.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
}
