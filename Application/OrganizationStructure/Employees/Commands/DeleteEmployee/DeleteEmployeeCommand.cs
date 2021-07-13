using System;
using MediatR;

namespace Application.OrganizationStructure.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
