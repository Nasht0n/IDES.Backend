using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteList
{
    public class GetIndexRequisiteListQuery:IRequest<IndexRequisiteListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
