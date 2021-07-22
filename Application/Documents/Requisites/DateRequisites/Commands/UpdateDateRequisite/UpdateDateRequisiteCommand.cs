using System;
using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Commands.UpdateDateRequisite
{
    public class UpdateDateRequisiteCommand:IRequest
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
    }
}
