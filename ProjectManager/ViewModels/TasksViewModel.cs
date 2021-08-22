using System.Collections.ObjectModel;
using ProjectManager.BL.DTO;

namespace ProjectManager.UI.ViewModels
{
    public class TasksViewModel
    {
        private ProjectDto _selectedProject;
        public ObservableCollection<ProjectDto> Projects;
        private TaskDto _selectedTask;
        public ObservableCollection<TaskDto> Tasks;
    }
}