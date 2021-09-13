using System;
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
        private Func<IUnitOfWork> _unitFactory;

        public ProjectService(Func<IUnitOfWork> unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public async Task<IEnumerable<ProjectDto>> GetByUserIdAsync(int userId)
        {
            IEnumerable<Project> projects;

            using(var unit = _unitFactory())
            {
                projects = await unit.Projects.GetWithTasksAsync(p => p.UserId == userId);
            }
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDto>());
            var mapper = config.CreateMapper();
            var projectsDto = mapper.Map<IEnumerable<ProjectDto>>(projects);

            return projectsDto;
        }

        public async Task UpdateProjectAsync(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);

            using(var unit = _unitFactory())
            {
                unit.Projects.Update(project);
                await unit.SaveAsync();
            }
            
        }

        public async Task CreateProjectAsync(ProjectDto projectDto)
        {
            var project = MapFromDto(projectDto);

            using(var unit = _unitFactory())
            {
                unit.Projects.Add(project);
                await unit.SaveAsync();
            }
        }

        public async Task DeleteProjectAsync(ProjectDto projectDto)
        {
            using(var unit = _unitFactory())
            {
                var project = MapFromDto(projectDto);
                unit.Projects.Delete(project);
                await unit.SaveAsync();
            }
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