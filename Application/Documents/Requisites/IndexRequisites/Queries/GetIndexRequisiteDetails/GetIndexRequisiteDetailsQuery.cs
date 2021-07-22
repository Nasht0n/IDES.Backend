using System;
using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteDetails
{
    public class GetIndexRequisiteDetailsQuery:IRequest<IndexRequisiteVm>
    {
        public Guid Id { get; set; }
    }
}
