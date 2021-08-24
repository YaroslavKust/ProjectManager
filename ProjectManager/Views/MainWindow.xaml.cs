using System.Collections.Generic;
using System.Windows;
using ProjectManager.BL.DTO;
using ProjectManager.UI.ViewModels;

namespace ProjectManager.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Str { get; set; }
        public List<TaskDto> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
