using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteList
{
    public class GetDateRequisiteListQuery:IRequest<DateRequisiteListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
