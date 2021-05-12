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
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaskCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Count > 0) { throw new Exceptions.ValidationException(result); }

            var task = _mapper.Map<Domain.Entities.Task>(request);
            task = await _taskRepository.AddAsync(task);
            return task.TaskId;
        }
    }
}
