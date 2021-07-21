using System;
using MediatR;

namespace Application.Documents.Casts.OrderApprovers.Commands.CreateOrderApprover
{
    public class CreateOrderApproverCommand:IRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid OrderDocumentId { get; set; }
        public int Rank { get; set; }
    }
}
