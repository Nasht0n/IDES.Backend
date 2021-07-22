using System;
using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.DeleteOrderDocument
{
    public class DeleteOrderDocumentCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
