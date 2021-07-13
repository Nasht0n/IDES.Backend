using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.OrganizationStructure;
using MediatR;

namespace Application.OrganizationStructure.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler:IRequestHandler<CreateDepartmentCommand, Guid>
    {
        private readonly IDbContext _context;

        public CreateDepartmentCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsDeleted = false
            };

            await _context.Departments.AddAsync(department, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return department.Id;
        }
    }
}
