using System;
using System.Collections.Generic;
using Domain.Models.Documents.Attachments;
using Domain.Models.Documents.Casts;
using Domain.Models.Documents.Requisites;

namespace Domain.Models.Documents.DocumentObjects
{
    public class OrderDocument:DocumentObject
    {
        public Guid? IndexId { get; set; }
        public Guid? DateTimeId { get; set; }

        public IList<OrderCreator> Creators { get; set; }
        public IList<OrderApprover> Approvers { get; set; }
        public IList<OrderAttachment> OrderAttachments { get; set; }

        public IndexRequisite Index { get; set; }
        public DateRequisite Date { get; set; }
    }
}
