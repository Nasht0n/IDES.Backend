using FluentValidation;

namespace Application.Documents.Requisites.TitleRequisites.Commands.CreateTitleRequisite
{
    public class CreateTitleRequisiteCommandValidator:AbstractValidator<CreateTitleRequisiteCommand>
    {
        public CreateTitleRequisiteCommandValidator()
        {
            RuleFor(req => req.Value).NotEmpty();
        }
    }
}
