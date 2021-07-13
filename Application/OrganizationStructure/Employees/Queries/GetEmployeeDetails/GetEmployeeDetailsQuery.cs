using System;
using MediatR;

namespace Application.OrganizationStructure.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQuery:IRequest<EmployeeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
