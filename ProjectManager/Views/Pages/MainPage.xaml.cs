using ProjectManager.BL.DTO;
using ProjectManager.UI.ViewModels;
using System.Windows.Controls;

namespace ProjectManager.UI.Views.Pages
{
    public partial class MainPage : Page
    {
        public MainPage(UserDto user)
        {
            InitializeComponent();
            DataContext = new MainPageViewModel(user);
        }
    }
}
