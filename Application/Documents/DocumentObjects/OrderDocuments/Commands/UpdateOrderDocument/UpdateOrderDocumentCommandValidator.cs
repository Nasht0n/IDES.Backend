using FluentValidation;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.UpdateOrderDocument
{
    public class UpdateOrderDocumentCommandValidator:AbstractValidator<UpdateOrderDocumentCommand>
    {
        public UpdateOrderDocumentCommandValidator()
        {
            RuleFor(document => document.Id).NotEmpty();
            RuleFor(document => document.TitleId).NotEmpty();
            RuleFor(document => document.TypeId).NotEmpty();
        }
    }
}
