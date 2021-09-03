using System.Collections;
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

        public ProjectDto Project
        {
            get => (ProjectDto)GetValue(ProjectProperty);
            set => SetValue(ProjectProperty, value);
        }

        public TaskDto SelectedTask
        {
            get => (TaskDto)GetValue(SelectedTaskProperty);
            set{
                MessageBox.Show("e");
                SetValue(SelectedTaskProperty, value);
            }
        }

        public IEnumerable<TaskDto> Tasks
        {
            get => (IEnumerable<TaskDto>)GetValue(TasksProperty);
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

        public static DependencyProperty ProjectProperty = 
            DependencyProperty.Register("Project", typeof(ProjectDto), typeof(TasksControl));

        public static DependencyProperty SelectedTaskProperty =
            DependencyProperty.Register("SelectedTask", typeof(TaskDto), typeof(TasksControl));

        public static DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(IEnumerable<TaskDto>), typeof(TasksControl));

        public static DependencyProperty UpdateCommandProperty =
            DependencyProperty.Register("Update", typeof(ICommand), typeof(TasksControl));

        public static DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("Remove", typeof(ICommand), typeof(TasksControl));

        public static DependencyProperty AddCommandProperty =
            DependencyProperty.Register("Add", typeof(ICommand), typeof(TasksControl));
    }
}
