using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteList
{
    public class GetDocumentTypeRequisiteListQuery:IRequest<DocumentTypeRequisiteListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
