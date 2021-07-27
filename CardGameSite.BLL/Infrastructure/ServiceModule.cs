using Ninject.Modules;
using CardGameSite.DAL.Interfaces;
using CardGameSite.DAL.Repositories;

namespace CardGameSite.BLL.Infrastructure
{
    class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }

    }
}

