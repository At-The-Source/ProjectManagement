﻿using AutoMapper;
using Blazored.LocalStorage;
using ProjectManagement.App.Contracts;
using ProjectManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.App.Services.DataServices
{
    public class TaskDataService : BaseDataService, ITaskDataService
    {

        private readonly IMapper _mapper;

        public TaskDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateTask(SpecificTaskViewModel specificTaskViewModel)
        {
            try
            {
                CreateTaskCommand createTask = _mapper.Map<CreateTaskCommand>(specificTaskViewModel);
                var task = await _client.AddTaskAsync(createTask);
                return new ApiResponse<Guid>() { Data = task, Success = true };
            }
            catch (ApiException e)
            {

                return ConvertApiExceptions<Guid>(e);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteTask(Guid taskId)
        {
            try
            {
                await _client.DeleteProjectAsync(taskId);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException e)
            {
                return ConvertApiExceptions<Guid>(e);
            }
        }

        public async Task<SpecificTaskViewModel> GetTaskById(Guid id)
        {
            var task = await _client.GetTaskByIdAsync(id);
            var map = _mapper.Map<SpecificTaskViewModel>(task);
            return map;
        }

        public async Task<ApiResponse<Guid>> UpdateTask(SpecificTaskViewModel specificTaskViewModel)
        {
            try
            {
                UpdateTaskCommand updateTaskCommand = _mapper.Map<UpdateTaskCommand>(specificTaskViewModel);
                await _client.UpdateTaskAsync(updateTaskCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException e)
            {

                return ConvertApiExceptions<Guid>(e);
            }
        }
    }
}
