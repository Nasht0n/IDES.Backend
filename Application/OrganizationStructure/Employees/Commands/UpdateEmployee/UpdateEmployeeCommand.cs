using System;
using MediatR;

namespace Application.OrganizationStructure.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand:IRequest
    {
        public Guid Id { get; set; }

        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public bool IsDeleted { get; set; }
    }
}
