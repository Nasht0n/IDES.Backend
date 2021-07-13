using System;
using MediatR;

namespace Application.OrganizationStructure.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand:IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
