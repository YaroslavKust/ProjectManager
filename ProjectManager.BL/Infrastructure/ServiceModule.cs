using Ninject.Modules;
using ProjectManager.DAL.UnitOfWorks;

namespace ProjectManager.BL.Infrastructure
{
    public class ServiceModule: NinjectModule
    {
        private string _connection;

        public ServiceModule(string connection)
        {
            _connection = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connection);
        }
    }
}