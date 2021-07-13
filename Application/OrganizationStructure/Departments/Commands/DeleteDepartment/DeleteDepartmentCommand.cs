using System;
using MediatR;

namespace Application.OrganizationStructure.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
