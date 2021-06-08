using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IAsyncRepository<Domain.Entities.Task> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.TaskId);
            if (task == null) { throw new NotFoundException(nameof(task), request.TaskId); }
            _mapper.Map(request, task, typeof(UpdateTaskCommand), typeof(Domain.Entities.Task));
            await _taskRepository.UpdateAsync(task);
            return Unit.Value;
        }
    }
}
