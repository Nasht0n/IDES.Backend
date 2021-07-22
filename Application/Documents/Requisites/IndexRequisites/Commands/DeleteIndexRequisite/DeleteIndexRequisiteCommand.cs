using System;
using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Commands.DeleteIndexRequisite
{
    public class DeleteIndexRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
