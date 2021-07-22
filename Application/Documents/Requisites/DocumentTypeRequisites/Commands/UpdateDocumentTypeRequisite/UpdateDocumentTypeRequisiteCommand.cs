using System;
using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.UpdateDocumentTypeRequisite
{
    public class UpdateDocumentTypeRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
