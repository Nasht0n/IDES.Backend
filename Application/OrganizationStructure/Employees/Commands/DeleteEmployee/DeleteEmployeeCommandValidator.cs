using FluentValidation;

namespace Application.OrganizationStructure.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator:AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(employee => employee.Id).NotEmpty();
        }
    }
}
