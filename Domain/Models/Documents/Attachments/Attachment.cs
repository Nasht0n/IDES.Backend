using System.Collections.Generic;

namespace Domain.Models.Documents.Attachments
{
    public class Attachment:BaseObject
    {
        public string Filename { get; set; }
        public string Extension { get; set; }
        public byte[] FileContent { get; set; }

        public IList<OrderAttachment> OrderAttachments { get; set; }
    }
}
