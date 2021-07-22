using System;
using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Commands.UpdateTitleRequisite
{
    public class UpdateTitleRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
