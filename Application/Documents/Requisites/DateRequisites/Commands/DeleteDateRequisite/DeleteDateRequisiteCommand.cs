using System;
using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Commands.DeleteDateRequisite
{
    public class DeleteDateRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
