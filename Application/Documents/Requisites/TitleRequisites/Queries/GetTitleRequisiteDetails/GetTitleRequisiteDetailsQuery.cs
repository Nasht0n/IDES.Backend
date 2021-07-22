using System;
using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteDetails
{
    public class GetTitleRequisiteDetailsQuery:IRequest<TitleRequisiteDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
