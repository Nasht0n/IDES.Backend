using System;
using Domain.Enums;
using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.CreateOrderDocument
{
    public class CreateOrderDocumentCommand:IRequest<Guid>
    {
        public Guid TypeId { get; set; }
        public Guid TitleId { get; set; }

        public Guid? IndexId { get; set; }
        public Guid? DateTimeId { get; set; }

        public DocumentState State { get; set; }
    }
}
