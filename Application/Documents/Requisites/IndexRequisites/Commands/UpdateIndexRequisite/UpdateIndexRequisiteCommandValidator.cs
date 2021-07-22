using FluentValidation;

namespace Application.Documents.Requisites.IndexRequisites.Commands.UpdateIndexRequisite
{
    public class UpdateIndexRequisiteCommandValidator:AbstractValidator<UpdateIndexRequisiteCommand>
    {
        public UpdateIndexRequisiteCommandValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
            RuleFor(req => req.Value).NotEmpty();
        }
    }
}
