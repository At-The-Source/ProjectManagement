using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Queries.GetProjectsListWithTasks
{
    public class GetProjectsListWithTasksQueryHandler : IRequestHandler<GetProjectsListWithTasksQuery, List<ProjectTaskListVM>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetProjectsListWithTasksQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<List<ProjectTaskListVM>> Handle(GetProjectsListWithTasksQuery request, CancellationToken cancellationToken)
        {
            var projectsWithTasks = await _projectRepository.GetProjectsWithTasks(request.IncludeHistory);
            return _mapper.Map<List<ProjectTaskListVM>>(projectsWithTasks);
        }
    }
}
