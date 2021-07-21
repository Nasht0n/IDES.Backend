using System;
using MediatR;

namespace Application.Documents.Casts.OrderCreators.Commands.DeleteOrderCreator
{
    public class DeleteOrderCreatorCommand:IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid OrderDocumentId { get; set; }
    }
}
