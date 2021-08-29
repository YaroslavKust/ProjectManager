using System;
using System.Windows;
using Ninject;
using ProjectManager.BL.Interfaces;
using ProjectManager.UI.Common;
using ProjectManager.UI.Views;

namespace ProjectManager.UI.ViewModels
{
    public class AuthenticationViewModel
    {
        private IAuthenticationService _authService;

        private RelayCommand _authCommand;

        public string AuthName { get; set; }
        public string AuthPassword { get; set; }

        public AuthenticationViewModel()
        {
            _authService = App.Container.Get<IAuthenticationService>();
        }

        public RelayCommand AuthCommand
        {
            get
            {
                return _authCommand ?? (_authCommand = new RelayCommand(async _ =>
                {
                    try
                    {
                        App.ActiveUser = await _authService.AuthorizeAsync(AuthName, AuthPassword);
                        var win = (MainWindow) Application.Current.MainWindow;
                        win.Frame.Navigate(new Uri("../Views/Pages/MainPage.xaml", UriKind.Relative));
                    }
                    catch
                    {
                        MessageBox.Show("Неверное имя пользователя или пароль");
                    }
                }));
            }
        }
    }
}