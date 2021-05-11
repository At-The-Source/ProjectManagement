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

namespace ProjectManagement.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IMapper _mapper;

        public DeleteProjectCommandHandler(IAsyncRepository<Project> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            await _projectRepository.DeleteAsync(project);
            return Unit.Value;
        }
    }
}
