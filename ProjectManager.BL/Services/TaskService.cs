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
        private Func<IUnitOfWork> _unitFactory;

        public TaskService(Func<IUnitOfWork> unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync(Func<TaskDto, bool> f)
        {
            IEnumerable<TaskDto> res;

            using (var unit = _unitFactory())
            {
                var tsks = await unit.Tasks.GetAsync(t => true);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<MyTask, TaskDto>());
                var mapper = config.CreateMapper();
                var tasks = mapper.Map<List<TaskDto>>(tsks);
                res = tasks.Where(f);
            }

            return res;
        }

        public async Task CreateTaskAsync(TaskDto task)
        {
            var myTask = MapFromDto(task);

            using(var unit = _unitFactory())
            {
                unit.Tasks.Add(myTask);
                await unit.SaveAsync();
            }

            task.Id = myTask.Id;
        }

        public async Task UpdateTaskAsync(TaskDto task)
        {
            var myTask = MapFromDto(task);

            using(var unit = _unitFactory())
            {
                unit.Tasks.Update(myTask);
                await unit.SaveAsync();
            }
            
        }

        public async Task DeleteTaskAsync(TaskDto task)
        {
            var myTask = MapFromDto(task);

            using(var unit = _unitFactory())
            {
                var t = await unit.Tasks.GetByIdAsync(myTask.Id);
                unit.Tasks.Delete(t);
                await unit.SaveAsync();
            }
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