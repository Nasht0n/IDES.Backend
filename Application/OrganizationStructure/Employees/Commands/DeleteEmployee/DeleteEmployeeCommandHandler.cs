using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.OrganizationStructure;
using MediatR;

namespace Application.OrganizationStructure.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler:IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IDbContext _context;
        public DeleteEmployeeCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
