using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.DocumentObjects;
using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.DeleteOrderDocument
{
    public class DeleteOrderDocumentCommandHandler:IRequestHandler<DeleteOrderDocumentCommand>
    {
        private readonly IDbContext _context;

        public DeleteOrderDocumentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteOrderDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderDocuments.FindAsync(new object[] { request.Id},cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderDocument), request.Id);
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
