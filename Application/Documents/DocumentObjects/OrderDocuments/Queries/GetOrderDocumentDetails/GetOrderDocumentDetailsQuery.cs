using System;
using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentDetails
{
    public class GetOrderDocumentDetailsQuery:IRequest<OrderDocumentVm>
    {
        public Guid Id { get; set; }
    }
}
