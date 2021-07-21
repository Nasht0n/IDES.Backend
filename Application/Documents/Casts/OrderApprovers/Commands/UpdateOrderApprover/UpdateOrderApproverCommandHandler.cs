using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Casts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Casts.OrderApprovers.Commands.UpdateOrderApprover
{
    public class UpdateOrderApproverCommandHandler:IRequestHandler<UpdateOrderApproverCommand>
    {
        private readonly IDbContext _context;

        public UpdateOrderApproverCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateOrderApproverCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderApprovers.FirstOrDefaultAsync(
                oa => oa.EmployeeId == request.EmployeeId && oa.DocumentId == request.OrderDocumentId,
                cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderApprover),
                    new object[] {request.EmployeeId, request.OrderDocumentId});
            }
            entity.Rank = request.Rank;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
