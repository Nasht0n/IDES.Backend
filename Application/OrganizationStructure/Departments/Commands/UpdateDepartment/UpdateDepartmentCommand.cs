using System;
using MediatR;

namespace Application.OrganizationStructure.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
