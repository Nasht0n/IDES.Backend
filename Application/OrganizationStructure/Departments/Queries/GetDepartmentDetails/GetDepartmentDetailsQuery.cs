using System;
using MediatR;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQuery:IRequest<DepartmentDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
