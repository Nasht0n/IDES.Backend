using FluentValidation;

namespace Application.Documents.Casts.OrderApprovers.Commands.DeleteOrderApprover
{
    public class DeleteOrderApproverCommandValidator:AbstractValidator<DeleteOrderApproverCommand>
    {
        public DeleteOrderApproverCommandValidator()
        {
            RuleFor(oa => oa.EmployeeId).NotEmpty();
            RuleFor(oa => oa.OrderDocumentId).NotEmpty();
        }
    }
}
