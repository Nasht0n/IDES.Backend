using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.OrganizationStructure;
using MediatR;

namespace Application.OrganizationStructure.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler:IRequestHandler<CreateEmployeeCommand,Guid>
    {
        private readonly IDbContext _context;
        public CreateEmployeeCommandHandler(IDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee {  
                Id = Guid.NewGuid(),
                DepartmentId = request.DepartmentId,
                Fullname = request.Fullname,
                Position = request.Position,
                Email = request.Email,
                IsDeleted = false
            };

            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
