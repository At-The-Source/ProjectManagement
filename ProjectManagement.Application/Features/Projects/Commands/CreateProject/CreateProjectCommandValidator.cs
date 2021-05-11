using FluentValidation;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            RuleFor(project => project.ProjectName)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a name.")
                .NotNull();

            RuleFor(project => project.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a description.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} can not exceed 200 characters.");

            RuleFor(project => project)
                .MustAsync(ProjectNameAndDescriptionUnique)
                .WithMessage("The project Name and Description is not unique and already exists.");
        }

        private async Task<bool> ProjectNameAndDescriptionUnique(CreateProjectCommand project, CancellationToken token)
        {
            return !(await _projectRepository.IsNameAndDescriptionUnique(project.ProjectName, project.Description));
        }
    }
}
