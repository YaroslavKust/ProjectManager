using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjectManager.BL.DTO;

namespace ProjectManager.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для TasksControl.xaml
    /// </summary>
    public partial class TasksControl : UserControl
    {
        public TasksControl()
        {
            InitializeComponent();
        }

        public string ProjectName
        {
            get => (string)GetValue(ProjectNameProperty);
            set => SetValue(ProjectNameProperty, value);
        }

        public List<TaskDto> Tasks
        {
            get => (List<TaskDto>)GetValue(TasksProperty);
            set => SetValue(TasksProperty, value);
        }

        public static DependencyProperty ProjectNameProperty = 
            DependencyProperty.Register("ProjectName", typeof(string), typeof(TasksControl));

        public static DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(List<TaskDto>), typeof(TasksControl));
    }
}
