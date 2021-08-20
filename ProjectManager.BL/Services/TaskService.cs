using AutoMapper;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.DAL.Models;
using ProjectManager.DAL.UnitOfWorks;

namespace ProjectManager.BL.Services
{
    public class TaskService: ITaskService
    {
        private IUnitOfWork _unit;

        public TaskService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public void CreateTask(TaskDto task)
        {
            var myTask = MapFromDto(task);
            _unit.Tasks.Add(myTask);
        }

        public void UpdateTask(TaskDto task)
        {
            var myTask = MapFromDto(task);
            _unit.Tasks.Update(myTask);
        }

        public void DeleteTask(TaskDto task)
        {
            var myTask = MapFromDto(task);
            _unit.Tasks.Delete(myTask);
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