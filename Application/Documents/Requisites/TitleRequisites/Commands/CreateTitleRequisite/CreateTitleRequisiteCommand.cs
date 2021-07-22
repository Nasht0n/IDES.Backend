using System;
using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Commands.CreateTitleRequisite
{
    public class CreateTitleRequisiteCommand:IRequest<Guid>
    {
        public string Value { get; set; }
    }
}
