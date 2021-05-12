using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Queries.GetTaskList
{
    public class GetTasksListQueryHandler : IRequestHandler<GetTasksListQuery, List<TaskListVM>>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksListQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Task> taskRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<List<TaskListVM>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
        {
            // get list of task entities & return viewModels based on the entities via automapper 
            var tasks = (await _taskRepository.ListAllAsync());
            return _mapper.Map<List<TaskListVM>>(tasks);
        }
    }
}
