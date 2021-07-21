using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Casts;
using MediatR;

namespace Application.Documents.Casts.OrderApprovers.Commands.CreateOrderApprover
{
    public class CreateOrderApproverCommandHandler:IRequestHandler<CreateOrderApproverCommand>
    {
        private readonly IDbContext _context;

        public CreateOrderApproverCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(CreateOrderApproverCommand request, CancellationToken cancellationToken)
        {
            OrderApprover approver = new()
            {
                DocumentId = request.OrderDocumentId,
                EmployeeId = request.EmployeeId,
                Rank = request.Rank
            };

            await _context.OrderApprovers.AddAsync(approver, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
