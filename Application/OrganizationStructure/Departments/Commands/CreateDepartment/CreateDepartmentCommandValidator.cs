using FluentValidation;

namespace Application.OrganizationStructure.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator:AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().MaximumLength(250);
        }
    }
}
