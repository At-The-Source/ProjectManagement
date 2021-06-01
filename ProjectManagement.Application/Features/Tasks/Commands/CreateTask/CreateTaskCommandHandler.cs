using AutoMapper;
using MediatR;
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

        public CreateTaskCommandHandler(IAsyncRepository<Domain.Entities.Task> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        //public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        //{
        //    var validator = new CreateTaskCommandValidator();
        //    var result = await validator.ValidateAsync(request);
        //    if (result.Errors.Count > 0) { throw new Exceptions.ValidationException(result); }

        //    var task = _mapper.Map<Domain.Entities.Task>(request);
        //    task = await _taskRepository.AddAsync(task);
        //    return task.TaskId;
        //}

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
                var newTask = new Domain.Entities.Task() { TaskName = request.TaskName, Description = request.Description };
                newTask = await _taskRepository.AddAsync(newTask);
                response.Task = _mapper.Map<CreateTaskDto>(newTask);
            }
            return response;
        }
    }
}
