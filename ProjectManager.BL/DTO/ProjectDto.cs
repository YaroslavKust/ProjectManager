using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectManager.BL.DTO
{
    public class ProjectDto : NotifyObject
    {
        private string _name;
        private ObservableCollection<TaskDto> tasks;

        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<TaskDto> Tasks 
        { 
            get => tasks; 
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
    }
}