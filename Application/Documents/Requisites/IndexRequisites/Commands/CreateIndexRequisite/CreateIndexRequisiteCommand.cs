using System;
using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Commands.CreateIndexRequisite
{
    public class CreateIndexRequisiteCommand:IRequest<Guid>
    {
        public string Value { get; set; }
    }
}
