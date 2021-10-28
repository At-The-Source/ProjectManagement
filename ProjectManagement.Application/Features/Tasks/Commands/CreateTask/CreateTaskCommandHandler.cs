using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTaskCommandHandler> _logger;

        public CreateTaskCommandHandler(IAsyncRepository<Domain.Entities.Task> taskRepository, IMapper mapper, ILogger<CreateTaskCommandHandler> logger)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateTaskCommandResponse();
            var validator = new CreateTaskCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in result.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                try
                {
                    var newTask = new Domain.Entities.Task() 
                    { 
                        TaskName = request.TaskName, 
                        Description = request.Description, 
                        TaskId = request.TaskId, 
                        ProjectId = request.ProjectId 
                    };
                    newTask = await _taskRepository.AddAsync(newTask);
                    response.Task = _mapper.Map<CreateTaskDto>(newTask);
                }
                catch (Exception e)
                {

                    _logger.LogError($"Adding task failed due to the following: {e.Message}");
                }
            }
            return response;
        }
    }
}
