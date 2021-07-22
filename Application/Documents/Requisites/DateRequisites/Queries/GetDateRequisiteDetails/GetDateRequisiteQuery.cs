using System;
using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteDetails
{
    public class GetDateRequisiteQuery:IRequest<DateRequisiteVm>
    {
        public Guid Id { get; set; }
    }
}
