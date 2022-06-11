using Ninject.Modules;
using PublishingActivity.BLL.Interfaces;
using PublishingActivity.BLL.Services;
using PublishingActivity.DAL.Interfaces;
using PublishingActivity.DAL.Repositories;

namespace PublishingActivity.BLL.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IPublicationService>().To<PublicationService>();
            Bind<IServiceCreator>().To<ServiceCreator>();
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("PublishingActivityDB");
        }
    }
}
