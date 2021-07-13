using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.OrganizationStructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrganizationStructure.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler:IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IDbContext _context;

        public UpdateDepartmentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Departments.FirstOrDefaultAsync(department => department.Id == request.Id,
                    cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            entity.Name = request.Name;
            entity.IsDeleted = request.IsDeleted;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
