using System;
using Domain.Models.Documents.DocumentObjects;

namespace Domain.Models.Documents.Attachments
{
    public class OrderAttachment
    {
        public Guid AttachmentId { get; set; }
        public Guid OrderDocumentId { get; set; }

        public Attachment Attachment { get; set; }
        public OrderDocument OrderDocument { get; set; }
    }
}
