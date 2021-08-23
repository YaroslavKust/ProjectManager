using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

        public ICommand Update
        {
            get => (ICommand) GetValue(UpdateCommandProperty);
            set => SetValue(UpdateCommandProperty, value);
        }

        public ICommand Remove
        {
            get => (ICommand)GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }

        public ICommand Add
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }

        public static DependencyProperty ProjectNameProperty = 
            DependencyProperty.Register("ProjectName", typeof(string), typeof(TasksControl));

        public static DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(List<TaskDto>), typeof(TasksControl));

        public static DependencyProperty UpdateCommandProperty =
            DependencyProperty.Register("Update", typeof(ICommand), typeof(TasksControl));

        public static DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("Remove", typeof(ICommand), typeof(TasksControl));

        public static DependencyProperty AddCommandProperty =
            DependencyProperty.Register("Add", typeof(ICommand), typeof(TasksControl));
    }
}
