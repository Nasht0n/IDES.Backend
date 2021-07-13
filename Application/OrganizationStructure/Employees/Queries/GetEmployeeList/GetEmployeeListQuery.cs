using MediatR;

namespace Application.OrganizationStructure.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery:IRequest<EmployeeListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
