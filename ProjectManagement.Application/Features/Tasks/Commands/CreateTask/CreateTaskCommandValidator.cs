using FluentValidation;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(task => task.TaskName)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a name.")
                .NotNull();

            RuleFor(task => task.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a description.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} can not exceed 200 characters.");
        }
    }
}
