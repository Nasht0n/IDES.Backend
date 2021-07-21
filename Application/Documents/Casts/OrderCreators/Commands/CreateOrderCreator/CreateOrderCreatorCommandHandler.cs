using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Casts;
using MediatR;

namespace Application.Documents.Casts.OrderCreators.Commands.CreateOrderCreator
{
    public class CreateOrderCreatorCommandHandler:IRequestHandler<CreateOrderCreatorCommand>
    {
        private readonly IDbContext _context;

        public CreateOrderCreatorCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(CreateOrderCreatorCommand request, CancellationToken cancellationToken)
        {
            OrderCreator creator = new()
            {
                EmployeeId = request.EmployeeId,
                DocumentId = request.OrderDocumentId
            };

            await _context.OrderCreators.AddAsync(creator, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
