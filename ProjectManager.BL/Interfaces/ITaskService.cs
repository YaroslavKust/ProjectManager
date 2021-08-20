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
        void CreateTask(TaskDto task);
        void UpdateTask(TaskDto task);
        void DeleteTask(TaskDto task);
    }
}