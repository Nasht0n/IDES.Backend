using FluentValidation;

namespace Application.Documents.Casts.OrderCreators.Commands.DeleteOrderCreator
{
    public class DeleteOrderCreatorCommandValidator:AbstractValidator<DeleteOrderCreatorCommand>
    {
        public DeleteOrderCreatorCommandValidator()
        {
            RuleFor(oc => oc.EmployeeId).NotEmpty();
            RuleFor(oc => oc.OrderDocumentId).NotEmpty();
        }
    }
}
