using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.UnitOfWorks;

namespace ProjectManager.BL.Services
{
    public class ProjectService: IProjectService
    {
        private IUnitOfWork _unit;

        public ProjectService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<ProjectDto>> GetByUserIdAsync(int userId)
        {
            var projects = (await _unit.Users.GetByIdAsync(userId)).Projects;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDto>());
            var mapper = config.CreateMapper();
            var projectsDto = mapper.Map<List<ProjectDto>>(projects);

            return projectsDto;
        }

        public void UpdateProject(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);
            _unit.Projects.Update(project);
        }

        public void CreateProject(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);
            _unit.Projects.Add(project);
        }

        public void DeleteProject(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);
            _unit.Projects.Delete(project);
        }

        private Project MapFromDto(ProjectDto projectDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDto, Project>());
            var mapper = config.CreateMapper();
            var project = mapper.Map<Project>(projectDto);
            return project;
        }
    }
}