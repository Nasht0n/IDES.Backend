using FluentValidation;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.CreateDocumentTypeRequisite
{
    public class CreateDocumentTypeRequisiteCommandValidator:AbstractValidator<CreateDocumentTypeRequisiteCommand>
    {
        public CreateDocumentTypeRequisiteCommandValidator()
        {
            RuleFor(req => req.Value).NotEmpty();
        }
    }
}
