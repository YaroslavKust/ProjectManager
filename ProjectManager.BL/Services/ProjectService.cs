using System.Collections.Generic;
using System.Linq;
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
            var projects = await _unit.Projects.GetWithTasksAsync(p => p.UserId == userId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDto>());
            var mapper = config.CreateMapper();
            var projectsDto = mapper.Map<IEnumerable<ProjectDto>>(projects);

            return projectsDto;
        }

        public void UpdateProject(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);
            _unit.Projects.Update(project);
            _unit.SaveAsync();
        }

        public void CreateProject(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);
            _unit.Projects.Add(project);
            _unit.SaveAsync();
        }

        public async void DeleteProject(ProjectDto projectDto)
        {
            var project =await _unit.Projects.GetByIdAsync(projectDto.Id);
            _unit.Projects.Delete(project);
            _unit.SaveAsync();
        }

        private Project MapFromDto(ProjectDto projectDto)
        {
            var mapt = new MapperConfiguration(cfg => cfg.CreateMap<TaskDto, MyTask>());
            var tmap = mapt.CreateMapper();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDto, Project>().
            ForMember(p=>p.Tasks, opt => opt.MapFrom(x => tmap.Map<List<MyTask>>(x.Tasks.ToList()))));
            var mapper = config.CreateMapper();
            var project = mapper.Map<Project>(projectDto);

            return project;
        }
    }
}