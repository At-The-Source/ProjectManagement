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

namespace ProjectManagement.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectCommandValidator(_projectRepository);
            var result = await validator.ValidateAsync(request);
            if(result.Errors.Count > 0) { throw new Exceptions.ValidationException(result); }

            var project = _mapper.Map<Project>(request);
            project = await _projectRepository.AddAsync(project);
            return project.ProjectId;
        }
    }
}
