using System;
using MediatR;

namespace Application.Documents.Casts.OrderCreators.Commands.CreateOrderCreator
{
    public class CreateOrderCreatorCommand:IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid OrderDocumentId { get; set; }
    }
}
