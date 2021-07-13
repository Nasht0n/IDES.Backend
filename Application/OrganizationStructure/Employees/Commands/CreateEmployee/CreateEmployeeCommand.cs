using System;
using MediatR;

namespace Application.OrganizationStructure.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand:IRequest<Guid>
    {
        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
