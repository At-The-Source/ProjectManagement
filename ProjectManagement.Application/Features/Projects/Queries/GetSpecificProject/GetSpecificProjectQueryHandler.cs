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
            //TODO: return a specific project query
            var project = await _projectRepository.GetByIdAsync(request.Id);
            var specificProjectVM = _mapper.Map<TaskDto>(project);
            return null;
        }
    }
}
