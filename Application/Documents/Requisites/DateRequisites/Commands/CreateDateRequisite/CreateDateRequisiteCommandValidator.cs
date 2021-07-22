using FluentValidation;

namespace Application.Documents.Requisites.DateRequisites.Commands.CreateDateRequisite
{
    public class CreateDateRequisiteCommandValidator:AbstractValidator<CreateDateRequisiteCommand>
    {
        public CreateDateRequisiteCommandValidator()
        {
            RuleFor(req => req.Date).NotEmpty();
        }
    }
}
