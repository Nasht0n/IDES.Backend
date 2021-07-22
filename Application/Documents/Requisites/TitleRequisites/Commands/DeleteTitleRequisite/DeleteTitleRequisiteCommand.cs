using System;
using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Commands.DeleteTitleRequisite
{
    public class DeleteTitleRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
