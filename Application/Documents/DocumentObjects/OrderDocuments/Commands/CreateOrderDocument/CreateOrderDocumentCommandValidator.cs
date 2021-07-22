using FluentValidation;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.CreateOrderDocument
{
    public class CreateOrderDocumentCommandValidator:AbstractValidator<CreateOrderDocumentCommand>
    {
        public CreateOrderDocumentCommandValidator()
        {
            RuleFor(document => document.TypeId).NotEmpty();
            RuleFor(document => document.TitleId).NotEmpty();
            RuleFor(document => document.State).NotEmpty();
        }
    }
}
