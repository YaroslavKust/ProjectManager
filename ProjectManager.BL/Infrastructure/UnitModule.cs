using Ninject.Modules;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.UnitOfWorks;
using System.Data.Entity;

namespace ProjectManager.BL.Infrastructure
{
    public class UnitModule: NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ManagerContext>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
        }
    }
}