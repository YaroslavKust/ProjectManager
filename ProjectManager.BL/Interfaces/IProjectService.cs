using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.BL.DTO;

namespace ProjectManager.BL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetByUserIdAsync(int userId);
        void UpdateProject(ProjectDto project);
        void DeleteProject(ProjectDto project);
        void CreateProject(ProjectDto project);
    }
}