using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BL.DTO
{
    public class ProjectDto : PropertyValidateModel
    {
        private string _name;
        private ObservableCollection<TaskDto> _tasks = new ObservableCollection<TaskDto>();

        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
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
            get => _tasks; 
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
    }
}