using System.Configuration;
using System.Windows;
using Ninject;
using ProjectManager.BL.Infrastructure;
using ProjectManager.Util;

namespace ProjectManager.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            string connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            var serviceModule = new ServiceModule();
            var unitModule = new UnitModule(connection);

            var container = new StandardKernel(serviceModule, unitModule);
            Current.MainWindow = container.Get<MainWindow>();
        }
    }
}
