using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.OrganizationStructure;
using MediatR;

namespace Application.OrganizationStructure.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler:IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IDbContext _context;

        public DeleteDepartmentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments.FindAsync(new object[] {request.Id}, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            _context.Departments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
