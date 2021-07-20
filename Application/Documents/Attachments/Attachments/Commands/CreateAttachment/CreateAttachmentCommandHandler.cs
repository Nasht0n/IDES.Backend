using Application.Interfaces;
using Domain.Models.Documents.Attachments;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Attachments.Attachments.Commands.CreateAttachment
{
    public class CreateAttachmentCommandHandler : IRequestHandler<CreateAttachmentCommand, Guid>
    {
        private readonly IDbContext _context;

        public CreateAttachmentCommandHandler(IDbContext context) => this._context = context;

        public async Task<Guid> Handle(CreateAttachmentCommand request, CancellationToken cancellationToken)
        {
            Attachment attachment = new() { 
                Id = Guid.NewGuid(),
                Filename = request.File.FileName,
                Extension = Path.GetExtension(request.File.FileName),
                IsDeleted = false                
            };

            using(var ms = new MemoryStream())
            {
                request.File.CopyTo(ms);
                attachment.FileContent = ms.ToArray();
            }

            await _context.Attachments.AddAsync(attachment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return attachment.Id;
        }
    }
}
