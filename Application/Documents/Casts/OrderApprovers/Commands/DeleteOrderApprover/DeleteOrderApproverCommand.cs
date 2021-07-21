using System;
using MediatR;

namespace Application.Documents.Casts.OrderApprovers.Commands.DeleteOrderApprover
{
    public class DeleteOrderApproverCommand:IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid OrderDocumentId { get; set; }
    }
}
