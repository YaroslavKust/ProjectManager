using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BL.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<ProjectDto> Projects { get; set; }
    }
}