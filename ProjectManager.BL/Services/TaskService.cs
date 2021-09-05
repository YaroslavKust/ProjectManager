using AutoMapper;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.BL.Services
{
    public class TaskService: ITaskService
    {
        private IUnitOfWork _unit;

        public TaskService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync(Func<TaskDto, bool> f)
        {
            var tsks = await _unit.Tasks.GetAsync(t => true);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MyTask, TaskDto>());
            var mapper = config.CreateMapper();
            var tasks = mapper.Map<List<TaskDto>>(tsks);
            var res = tasks.Where(f);
            return res;
        }

        public void CreateTask(TaskDto task)
        {
            var myTask = MapFromDto(task);
            _unit.Tasks.Add(myTask);
            _unit.SaveAsync();
        }

        public void UpdateTask(TaskDto task)
        {
            var myTask = MapFromDto(task);
            _unit.Tasks.Update(myTask);
            _unit.SaveAsync();
        }

        public async void DeleteTask(TaskDto task)
        {
            var myTask = MapFromDto(task);
            var t = await _unit.Tasks.GetByIdAsync(myTask.Id);
            _unit.Tasks.Delete(t);
            _unit.SaveAsync();
        }

        private MyTask MapFromDto(TaskDto taskDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TaskDto, MyTask>());
            var mapper = config.CreateMapper();
            var myTask = mapper.Map<MyTask>(taskDto);

            return myTask;
        }
    }
}