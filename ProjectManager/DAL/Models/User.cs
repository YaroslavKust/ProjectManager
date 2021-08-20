using System.Collections.Generic;

namespace ProjectManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Project> Projects { get; set; }
    }
}