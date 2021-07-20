using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Attachments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Attachments.Attachments.Commands.UpdateAttachment
{
    public class UpdateAttachmentCommandHandler : IRequestHandler<UpdateAttachmentCommand>
    {
        private readonly IDbContext _context;

        public UpdateAttachmentCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateAttachmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Attachments.FirstOrDefaultAsync(attachment => attachment.Id == request.Id, cancellationToken);
            if(entity== null)
            {
                throw new NotFoundException(nameof(Attachment), request.Id);
            }

            entity.Filename = request.File.FileName;
            entity.Extension = Path.GetExtension(request.File.FileName);
            using(var ms = new MemoryStream())
            {
                request.File.CopyTo(ms);
                entity.FileContent = ms.ToArray();
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
