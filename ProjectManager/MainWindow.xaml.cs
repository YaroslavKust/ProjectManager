using System.Collections.Generic;
using System.Windows;
using ProjectManager.BL.DTO;

namespace ProjectManager.UI
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
            Tasks = new List<TaskDto>() {new TaskDto() {Description = "qwerty", Priority = Priority.High, ProgressInPercents = 10}};
            Str = "s";
            DataContext = this;
        }
    }
}
