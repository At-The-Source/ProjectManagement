using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProjectCommandHandler> _logger;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper, ILogger<CreateProjectCommandHandler> logger)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateProjectCommandResponse();
            var validator = new CreateProjectCommandValidator(_projectRepository);
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Count > 0) 
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in result.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                try
                {
                    var newProject = new Domain.Entities.Project() 
                    {
                        ProjectId = request.ProjectId,
                        ProjectName = request.ProjectName,
                        Description = request.Description,
                    };
                    newProject = await _projectRepository.AddAsync(newProject);
                    response.Project = _mapper.Map<CreateProjectDto>(newProject);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Adding project failed due to the following: {e.Message}");
                }
            }

            return response;
        }
    }
}
