using System;
using MediatR;

namespace Application.Documents.Attachments.OrderAttachments.Commands.DeleteOrderAttachment
{
    public class DeleteOrderAttachmentCommand:IRequest
    {
        public Guid AttachmentId { get; set; }
        public Guid OrderDocumentId { get; set; }
    }
}
