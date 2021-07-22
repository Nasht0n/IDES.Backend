using System;
using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Commands.UpdateIndexRequisite
{
    public class UpdateIndexRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
