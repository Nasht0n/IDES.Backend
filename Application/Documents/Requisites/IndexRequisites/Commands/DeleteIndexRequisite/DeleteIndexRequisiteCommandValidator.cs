using FluentValidation;

namespace Application.Documents.Requisites.IndexRequisites.Commands.DeleteIndexRequisite
{
    public class DeleteIndexRequisiteCommandValidator:AbstractValidator<DeleteIndexRequisiteCommand>
    {
        public DeleteIndexRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
