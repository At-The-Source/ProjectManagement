using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Queries.GetSpecificTask
{
    public class GetSpecificTaskQueryHandler : IRequestHandler<GetSpecificTaskQuery, SpecificTaskVM>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetSpecificTaskQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<SpecificTaskVM> Handle(GetSpecificTaskQuery request, CancellationToken cancellationToken)
        {
            // Get specific task
            var task = await _taskRepository.GetByIdAsync(request.TaskId);
            var specificTaskVM = _mapper.Map<SpecificTaskVM>(task);
            return specificTaskVM;
        }
    }
}
