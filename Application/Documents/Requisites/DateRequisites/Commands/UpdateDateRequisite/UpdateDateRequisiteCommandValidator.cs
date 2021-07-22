using FluentValidation;

namespace Application.Documents.Requisites.DateRequisites.Commands.UpdateDateRequisite
{
    public class UpdateDateRequisiteCommandValidator:AbstractValidator<UpdateDateRequisiteCommand>
    {
        public UpdateDateRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
            RuleFor(req => req.Date).NotEmpty();
        }
    }
}
