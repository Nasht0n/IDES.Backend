using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.OrganizationStructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrganizationStructure.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler:IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IDbContext _context;

        public UpdateEmployeeCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            entity.DepartmentId = request.DepartmentId;
            entity.Email = request.Email;
            entity.Fullname = request.Fullname;
            entity.Position = request.Position;
            entity.IsDeleted = request.IsDeleted;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
