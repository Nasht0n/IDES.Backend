using System;
using FluentValidation;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQueryValidator:AbstractValidator<GetDepartmentDetailsQuery>
    {
        public GetDepartmentDetailsQueryValidator()
        {
            RuleFor(department => department.Id).NotEqual(Guid.Empty);
        }
    }
}
