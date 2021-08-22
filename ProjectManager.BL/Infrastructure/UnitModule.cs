using Ninject.Modules;
using ProjectManager.DAL.UnitOfWorks;

namespace ProjectManager.BL.Infrastructure
{
    public class UnitModule: NinjectModule
    {
        private string _connection;

        public UnitModule(string connection)
        {
            _connection = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connection);
        }
    }
}