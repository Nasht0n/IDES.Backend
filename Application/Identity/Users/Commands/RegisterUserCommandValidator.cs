using FluentValidation;

namespace Application.Identity.Users.Commands
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(command => command.EmployeeId).NotEmpty();
            RuleFor(command => command.Username).NotEmpty().MaximumLength(250);
            RuleFor(command => command.Password).NotEmpty().MaximumLength(250);
        }
    }
}
