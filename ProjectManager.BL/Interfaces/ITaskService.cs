using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManager.BL.DTO;
using ProjectManager.DAL.Models;

namespace ProjectManager.BL.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasksAsync(Func<TaskDto,bool> f);
        void CreateTask(TaskDto task);
        void UpdateTask(TaskDto task);
        void DeleteTask(TaskDto task);
    }
}