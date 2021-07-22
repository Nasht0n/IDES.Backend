using FluentValidation;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.UpdateDocumentTypeRequisite
{
    public class UpdateDocumentTypeRequisiteCommandValidator:AbstractValidator<UpdateDocumentTypeRequisiteCommand>
    {
        public UpdateDocumentTypeRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
            RuleFor(req => req.Value).NotEmpty();
        }
    }
}
