using MediatR;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQuery:IRequest<DepartmentListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
