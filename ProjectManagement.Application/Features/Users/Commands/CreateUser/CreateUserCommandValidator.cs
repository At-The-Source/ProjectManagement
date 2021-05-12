using FluentValidation;
using ProjectManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a first name.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed 50 characters.");

            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a last name.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed 50 characters.");

            RuleFor(user => user.UserName)
                .NotEmpty()
                .WithMessage("{PropertyName} requires a user name.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed 50 characters.");

            RuleFor(user => user)
                .MustAsync(UserNameUnique)
                .WithMessage("The user name is already taken.");
        }

        private async Task<bool> UserNameUnique(CreateUserCommand user, CancellationToken token)
        {
            return !(await _userRepository.IsUserNameUnique(user.UserName));
        }
    }
}
