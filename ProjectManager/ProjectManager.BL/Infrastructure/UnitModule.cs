using Ninject.Modules;
using ProjectManager.BL.Interfaces;
using ProjectManager.DAL.UnitOfWorks;

namespace ProjectManager.BL.Infrastructure
{
    public class UnitModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
        }
    }
}