using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.BL.DTO;

namespace ProjectManager.BL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetByUserIdAsync(int userId);
        Task UpdateProjectAsync(ProjectDto project);
        Task DeleteProjectAsync(ProjectDto project);
        Task CreateProjectAsync(ProjectDto project);
    }
}