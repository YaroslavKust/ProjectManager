using System;
using System.Configuration;
using System.Globalization;
using System.Windows;
using Ninject;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Infrastructure;
using ProjectManager.UI.Util;
using ProjectManager.UI.ViewModels;
using ProjectManager.UI.Views;

namespace ProjectManager.UI
{
    public partial class App : Application
    {
        public static UserDto ActiveUser { get; set; }

        private IKernel _container;
        public static IKernel Container { get; private set; }

        public App()
        {
            LanguageManager.Languages.Add(new CultureInfo("ru-RU"));
            LanguageManager.Languages.Add(new CultureInfo("en-US"));
        }

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

            _container = new StandardKernel(serviceModule, unitModule);
            Container = _container;

            var window = _container.Get<MainWindow>();
            var a = new MainWindow();
            var viewmodel = _container.Get<MainWindowViewModel>();
            window.DataContext = viewmodel;
            window.Frame.Source = new Uri("../Pages/Authentication.xaml", UriKind.Relative);
            Current.MainWindow = window;
        }
    }
}
