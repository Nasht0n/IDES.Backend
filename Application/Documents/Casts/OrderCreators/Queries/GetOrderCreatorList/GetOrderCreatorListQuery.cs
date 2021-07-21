using System;
using MediatR;

namespace Application.Documents.Casts.OrderCreators.Queries.GetOrderCreatorList
{
    public class GetOrderCreatorListQuery:IRequest<OrderCreatorListVm>
    {
        public Guid OrderDocumentId { get; set; }
    }
}
