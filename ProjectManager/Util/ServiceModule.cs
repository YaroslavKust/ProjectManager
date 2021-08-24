using Ninject.Modules;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Services;

namespace ProjectManager.UI.Util
{
    public class ServiceModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectService>().To<ProjectService>();
            Bind<ITaskService>().To<TaskService>();
            Bind<IAuthenticationService>().To<AuthenticationService>();
        }
    }
}