using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.Documents.Attachments.Attachments.Commands.CreateAttachment
{
    public class CreateAttachmentCommand:IRequest<Guid>
    {
        public IFormFile File { get; set; }
    }
}
