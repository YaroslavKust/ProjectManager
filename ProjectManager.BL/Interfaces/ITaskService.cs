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
        Task CreateTaskAsync(TaskDto task);
        Task UpdateTaskAsync(TaskDto task);
        Task DeleteTaskAsync(TaskDto task);
    }
}