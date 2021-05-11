using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Application.Contracts.Persistence;
using AutoMapper;
using ProjectManagement.Domain.Entities;
using System.Threading;

namespace ProjectManagement.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IAsyncRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            // Get project
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            // Map it
            _mapper.Map(request, project, typeof(UpdateProjectCommand), typeof(Project));
            // Update it
            await _projectRepository.UpdateAsync(project);
            // MediatR requirement for Return nothing
            return Unit.Value;
        }
    }
}
