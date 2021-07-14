using System;
using FluentValidation;

namespace Application.OrganizationStructure.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator:AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(updateCommand => updateCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateCommand => updateCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(updateCommand => updateCommand.IsDeleted).NotEmpty();
        }
    }
}
