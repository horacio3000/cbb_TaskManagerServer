﻿using System;
using Cyberbit.TaskManager.Server.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cyberbit.TaskManager.Server.Models.Enums;

namespace Cyberbit.TaskManager.Server.Bl
{
    public class TasksBl : ITasksBl
    {
        private readonly ILogger<TasksBl> _logger;
        private readonly ITasksDal _tasksDal;

        public TasksBl(ILogger<TasksBl> logger, ITasksDal TasksDal)
        {
            _logger = logger;
            _tasksDal = TasksDal;
        }

        public async Task<IList<Models.Task>> GetAllTask()
        {
            _logger.LogInformation($"GetAllTask - Enter");
            var retValue = await _tasksDal.GetAllTask();
            _logger.LogInformation($"GetAllTask - Exit");
            return retValue;
        }

        public async Task<Models.Task> GetTaskById(int id)
        {
            _logger.LogInformation($"GetTaskById - Enter");
            var retValue = await _tasksDal.GetTaskById(id);
            _logger.LogInformation($"GetTaskById - Exit");
            return retValue;
        }

        public async Task<Models.Task> AddTask(Models.Task task, int createdByUserId)
        {
            _logger.LogInformation($"AddTask - Enter");
            task.CreatedByUserId = createdByUserId;
            task.CreationTime = DateTime.Now;
            task.Status = TasksStatus.Open;
            var retValue = await _tasksDal.AddTask(task);
            _logger.LogInformation($"AddTask - Exit");
            return retValue;
        }

        public async Task<Models.Task> UpdateTask(Models.Task task)
        {
            _logger.LogInformation($"UpdateTask - Enter");
            var dbTask = await GetTaskById(task.Id);
            task.CreatedByUserId = dbTask.CreatedByUserId;
            task.UserId = dbTask.UserId;
            task.CreationTime = dbTask.CreationTime;
            var retValue = await _tasksDal.UpdateTask(task);
            _logger.LogInformation($"UpdateTask - Exit");
            return retValue;
        }

        public async Task<Models.Task> DeleteTaskById(int id)
        {
            _logger.LogInformation($"DeleteTaskById - Enter");
            var retValue = await _tasksDal.DeleteTaskById(id);
            _logger.LogInformation($"DeleteTaskById - Exit");
            return retValue;
        }
    }
}
