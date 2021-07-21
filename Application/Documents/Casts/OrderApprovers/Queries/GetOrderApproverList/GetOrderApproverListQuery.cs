using System;
using MediatR;

namespace Application.Documents.Casts.OrderApprovers.Queries.GetOrderApproverList
{
    public class GetOrderApproverListQuery:IRequest, IRequest<OrderApproverListVm>
    {
        public Guid OrderDocumentId { get; set; }
    }
}
