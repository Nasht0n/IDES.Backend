using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Casts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Casts.OrderCreators.Commands.DeleteOrderCreator
{
    public class DeleteOrderCreatorCommandHandler:IRequestHandler<DeleteOrderCreatorCommand>
    {
        private readonly IDbContext _context;

        public DeleteOrderCreatorCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteOrderCreatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderCreators.FirstOrDefaultAsync(
                oc => oc.EmployeeId == request.EmployeeId && oc.DocumentId == request.OrderDocumentId,
                cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderCreator),
                    new object[] {request.EmployeeId, request.OrderDocumentId});
            }

            _context.OrderCreators.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
