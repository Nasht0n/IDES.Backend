using System;
using Domain.Enums;
using Domain.Models.Documents.Requisites;

namespace Domain.Models
{
    public abstract class DocumentObject:BaseObject
    {
        public Guid TypeId { get; set; }
        public Guid TitleId { get; set; }

        public DocumentTypeRequisite DocumentType { get; set; }
        public TitleRequisite Title { get; set; }

        public DocumentState State { get; set; }
    }
}
