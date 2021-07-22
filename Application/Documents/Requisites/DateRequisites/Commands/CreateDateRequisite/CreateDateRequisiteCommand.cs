using System;
using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Commands.CreateDateRequisite
{
    public class CreateDateRequisiteCommand:IRequest<Guid>
    {
        public DateTime Date { get; set; }
    }
}
