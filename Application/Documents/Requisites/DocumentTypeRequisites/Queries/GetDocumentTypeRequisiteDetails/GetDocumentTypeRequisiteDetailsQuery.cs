using System;
using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteDetails
{
    public class GetDocumentTypeRequisiteDetailsQuery:IRequest<DocumentTypeRequisiteVm>
    {
        public Guid Id { get; set; }
    }
}
