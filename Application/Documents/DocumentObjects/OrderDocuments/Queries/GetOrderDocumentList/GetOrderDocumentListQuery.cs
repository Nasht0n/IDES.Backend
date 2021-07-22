using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentList
{
    public class GetOrderDocumentListQuery:IRequest<OrderDocumentListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
