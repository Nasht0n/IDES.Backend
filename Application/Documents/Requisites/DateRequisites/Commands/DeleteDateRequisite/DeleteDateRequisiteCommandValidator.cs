using FluentValidation;

namespace Application.Documents.Requisites.DateRequisites.Commands.DeleteDateRequisite
{
    public class DeleteDateRequisiteCommandValidator:AbstractValidator<DeleteDateRequisiteCommand>
    {
        public DeleteDateRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
