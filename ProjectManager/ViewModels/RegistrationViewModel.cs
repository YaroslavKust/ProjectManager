using System.Windows;
using System.Windows.Input;
using Ninject;
using ProjectManager.BL.Interfaces;
using ProjectManager.UI.Common;

namespace ProjectManager.UI.ViewModels
{
    public class RegistrationViewModel
    {
        private IAuthenticationService _authService;

        private RelayCommand  _registerCommand;

        public string RegName { get; set; }
        public string RegPassword { get; set; }
        public string ConfirmedPassword { get; set; }

        public RegistrationViewModel()
        {
            _authService = App.Container.Get<IAuthenticationService>();
        }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ?? (_registerCommand = new RelayCommand(async _ =>
                {
                    if (ConfirmedPassword != RegPassword)
                    {
                        MessageBox.Show("Пароли не совпадают");
                        return;
                    }

                    Mouse.OverrideCursor = Cursors.Wait;
                    await _authService.RegisterAsync(RegName, RegPassword);
                    Mouse.OverrideCursor = Cursors.Arrow;
                    MessageBox.Show("Регистрация прошла успешно, вы можете перейти на вкладку авторизации и войти в систему");
                }));
            }
        }
    }
}