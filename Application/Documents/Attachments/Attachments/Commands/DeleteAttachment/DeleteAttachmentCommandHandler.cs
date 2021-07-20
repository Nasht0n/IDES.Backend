using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Attachments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Attachments.Attachments.Commands.DeleteAttachment
{
    public class DeleteAttachmentCommandHandler : IRequestHandler<DeleteAttachmentCommand>
    {
        private readonly IDbContext _context;

        public DeleteAttachmentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Attachments.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Attachment), request.Id);
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
