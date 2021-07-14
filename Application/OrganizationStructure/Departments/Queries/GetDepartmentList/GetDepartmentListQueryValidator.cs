using FluentValidation;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryValidator:AbstractValidator<GetDepartmentListQuery>
    {
        public GetDepartmentListQueryValidator()
        {
            RuleFor(department => department.IsDeleted).NotEmpty();
        }
    }
}
