using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectManager.BL.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<ProjectDto> Projects { get; set; }
    }
}