using AutoMapper;
using MediatR;
using ProjectManagement.Application.Contracts.Persistence;
using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects
{
    public class GetSpecificProjectQueryHandler : IRequestHandler<GetSpecificProjectQuery, SpecificProjectVM>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetSpecificProjectQueryHandler(IMapper mapper, IAsyncRepository<Project> projectRepository, IAsyncRepository<Domain.Entities.Task> taskRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<SpecificProjectVM> Handle(GetSpecificProjectQuery request, CancellationToken cancellationToken)
        {
            //Get project
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            var specificProjectVM = _mapper.Map<SpecificProjectVM>(project);

            // Get project task
            // TODO: Change specific project retrieval
            //var task = await _taskRepository.GetByIdAsync(project.TaskId);
            //specificProjectVM.Tasks = _mapper.Map<TaskDto>(task);
            return specificProjectVM;
        }
    }
}
