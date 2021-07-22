using FluentValidation;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.DeleteDocumentTypeRequisite
{
    public class DeleteDocumentTypeRequisiteCommandValidator:AbstractValidator<DeleteDocumentTypeRequisiteCommand>
    {
        public DeleteDocumentTypeRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
