using MediatR;
using System;

namespace Application.Documents.Attachments.Attachments.Commands.DeleteAttachment
{
    public class DeleteAttachmentCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
