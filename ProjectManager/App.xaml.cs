using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using Ninject;
using ProjectManager.BL.Infrastructure;
using ProjectManager.UI.Util;
using ProjectManager.UI.Views;

namespace ProjectManager.UI
{
    public partial class App : Application
    {
       
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

            var container = new StandardKernel(serviceModule, unitModule);
            Current.MainWindow = container.Get<MainWindow>();
        }
    }
}
