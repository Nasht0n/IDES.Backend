using System;
using FluentValidation;

namespace Application.OrganizationStructure.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandValidator:AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(deleteCommand => deleteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
