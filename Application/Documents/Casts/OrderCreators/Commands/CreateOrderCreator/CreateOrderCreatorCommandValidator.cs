using FluentValidation;

namespace Application.Documents.Casts.OrderCreators.Commands.CreateOrderCreator
{
    public class CreateOrderCreatorCommandValidator:AbstractValidator<CreateOrderCreatorCommand>
    {
        public CreateOrderCreatorCommandValidator()
        {
            RuleFor(oc => oc.EmployeeId).NotEmpty();
            RuleFor(oc => oc.OrderDocumentId).NotEmpty();
        }
    }
}
