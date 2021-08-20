using System.Collections.ObjectModel;
using ProjectManager.Models;

namespace ProjectManager.UI.ViewModels
{
    public class ProjectViewModel
    {
        private Project _selectedProject;
        public ObservableCollection<Project> Projects;
        private MyTask _selectedTask;
        public ObservableCollection<MyTask> Tasks;
    }
}