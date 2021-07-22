using FluentValidation;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.DeleteOrderDocument
{
    public class DeleteOrderDocumentCommandValidator:AbstractValidator<DeleteOrderDocumentCommand>
    {
        public DeleteOrderDocumentCommandValidator()
        {
            RuleFor(document => document.Id).NotEmpty();
        }
    }
}
