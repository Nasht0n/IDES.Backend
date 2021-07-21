using FluentValidation;

namespace Application.Documents.Casts.OrderApprovers.Commands.UpdateOrderApprover
{
    public class UpdateOrderApproverCommandValidator:AbstractValidator<UpdateOrderApproverCommand>
    {
        public UpdateOrderApproverCommandValidator()
        {
            RuleFor(oa => oa.EmployeeId).NotEmpty();
            RuleFor(oa => oa.OrderDocumentId).NotEmpty();
            RuleFor(oa => oa.Rank).NotEmpty().GreaterThan(0);
        }
    }
}
