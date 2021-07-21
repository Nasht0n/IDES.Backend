using FluentValidation;

namespace Application.Documents.Casts.OrderApprovers.Commands.CreateOrderApprover
{
    public class CreateOrderApproverCommandValidator:AbstractValidator<CreateOrderApproverCommand>
    {
        public CreateOrderApproverCommandValidator()
        {
            RuleFor(oa => oa.EmployeeId).NotEmpty();
            RuleFor(oa => oa.OrderDocumentId).NotEmpty();
            RuleFor(oa => oa.Rank).NotEmpty().GreaterThan(0);
        }
    }
}
