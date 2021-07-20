using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.Documents.Attachments.Attachments.Commands.UpdateAttachment
{
    public class UpdateAttachmentCommand: IRequest
    {
        public Guid Id { get; set; }        
        public IFormFile File { get; set; }
    }
}
