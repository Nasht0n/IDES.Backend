using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.DocumentObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.UpdateOrderDocument
{
    public class UpdateOrderDocumentCommandHandler:IRequestHandler<UpdateOrderDocumentCommand>
    {
        private readonly IDbContext _context;

        public UpdateOrderDocumentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateOrderDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.OrderDocuments.FirstOrDefaultAsync(od => od.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderDocument), request.Id);
            }

            entity.TitleId = request.TitleId;
            entity.State = request.State;
            entity.TypeId = request.TypeId;
            entity.IndexId = request.IndexId;
            entity.DateTimeId = request.DateTimeId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
