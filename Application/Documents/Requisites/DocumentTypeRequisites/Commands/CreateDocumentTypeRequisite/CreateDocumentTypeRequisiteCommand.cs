using System;
using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.CreateDocumentTypeRequisite
{
    public class CreateDocumentTypeRequisiteCommand:IRequest<Guid>
    {
        public string Value { get; set; }
    }
}
