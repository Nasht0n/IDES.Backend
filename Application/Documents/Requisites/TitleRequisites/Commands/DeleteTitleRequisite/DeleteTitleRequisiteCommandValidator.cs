using FluentValidation;

namespace Application.Documents.Requisites.TitleRequisites.Commands.DeleteTitleRequisite
{
    public class DeleteTitleRequisiteCommandValidator:AbstractValidator<DeleteTitleRequisiteCommand>
    {
        public DeleteTitleRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
