using System;
using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.DeleteDocumentTypeRequisite
{
    public class DeleteDocumentTypeRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
