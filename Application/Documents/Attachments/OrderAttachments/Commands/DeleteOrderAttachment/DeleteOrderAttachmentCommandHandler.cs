using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Attachments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Attachments.OrderAttachments.Commands.DeleteOrderAttachment
{
    public class DeleteOrderAttachmentCommandHandler:IRequestHandler<DeleteOrderAttachmentCommand>
    {
        private readonly IDbContext _context;

        public DeleteOrderAttachmentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteOrderAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrderAttachments.FirstOrDefaultAsync(oa =>
                oa.AttachmentId == request.AttachmentId && oa.OrderDocumentId == request.OrderDocumentId, cancellationToken);
           
            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderAttachment), request.AttachmentId);
            }

            _context.OrderAttachments.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
