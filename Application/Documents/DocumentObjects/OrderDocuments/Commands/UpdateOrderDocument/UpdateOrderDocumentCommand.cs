using System;
using Domain.Enums;
using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.UpdateOrderDocument
{
    public class UpdateOrderDocumentCommand:IRequest
    {
        public Guid Id { get; set; }

        public Guid TypeId { get; set; }
        public Guid TitleId { get; set; }

        public Guid? IndexId { get; set; }
        public Guid? DateTimeId { get; set; }

        public DocumentState State { get; set; }
    }
}
