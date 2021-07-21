using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Attachments;
using MediatR;

namespace Application.Documents.Attachments.OrderAttachments.Commands.CreateOrderAttachment
{
    public class CreateOrderAttachmentCommandHandler:IRequestHandler<CreateOrderAttachmentCommand>
    {
        private readonly IDbContext _context;

        public CreateOrderAttachmentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(CreateOrderAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = new OrderAttachment()
            {
                AttachmentId = request.AttachmentId,
                OrderDocumentId = request.OrderDocumentId
            };

            await _context.OrderAttachments.AddAsync(attachment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
