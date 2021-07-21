using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Casts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Casts.OrderApprovers.Commands.DeleteOrderApprover
{
    public class DeleteOrderApproverCommandHandler:IRequestHandler<DeleteOrderApproverCommand>
    {
        private readonly IDbContext _context;

        public DeleteOrderApproverCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteOrderApproverCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderApprovers.FirstOrDefaultAsync(oa =>
                oa.EmployeeId == request.EmployeeId && oa.DocumentId == request.OrderDocumentId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderApprover), new object[] {request.EmployeeId, request.OrderDocumentId});
            }

            _context.OrderApprovers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;;
        }
    }
}
