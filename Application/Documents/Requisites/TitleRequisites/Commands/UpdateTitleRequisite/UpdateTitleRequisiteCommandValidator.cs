using FluentValidation;

namespace Application.Documents.Requisites.TitleRequisites.Commands.UpdateTitleRequisite
{
    public class UpdateTitleRequisiteCommandValidator:AbstractValidator<UpdateTitleRequisiteCommand>
    {
        public UpdateTitleRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
            RuleFor(req => req.Value).NotEmpty();
        }
    }
}
