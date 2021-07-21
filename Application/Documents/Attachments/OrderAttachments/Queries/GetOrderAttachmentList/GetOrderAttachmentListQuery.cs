using System;
using MediatR;

namespace Application.Documents.Attachments.OrderAttachments.Queries.GetOrderAttachmentList
{
    public class GetOrderAttachmentListQuery:IRequest<OrderAttachmentListVm>
    {
        public Guid OrderDocumentId { get; set; }
    }
}
