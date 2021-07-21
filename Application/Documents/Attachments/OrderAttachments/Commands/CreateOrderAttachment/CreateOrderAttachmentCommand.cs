using System;
using MediatR;

namespace Application.Documents.Attachments.OrderAttachments.Commands.CreateOrderAttachment
{
    public class CreateOrderAttachmentCommand:IRequest
    {
        public Guid AttachmentId { get; set; }
        public Guid OrderDocumentId { get; set; }
    }
}
