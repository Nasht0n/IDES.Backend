using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteList
{
    public class GetTitleRequisiteListQuery:IRequest<TitleRequisiteListVm>
    {
        public bool IsDelete { get; set; }
    }
}
