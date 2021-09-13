using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManager.UI
{
    class DefaultMessenger: IMessenger
    {
        public async void SendMessage(string text)
        {
            var window = Application.Current.MainWindow as MetroWindow;
            await window.ShowMessageAsync("", text);
        }

        public async Task<bool> SendConfirmMessage(string text)
        {
            var settings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No"
            };

            var window = Application.Current.MainWindow as MetroWindow;
            var res = await window.ShowMessageAsync("", text,MessageDialogStyle.AffirmativeAndNegative);
           // var res = MessageBox.Show(text, "", MessageBoxButton.YesNo);
            return res == MessageDialogResult.Affirmative;
        }
    }
}
