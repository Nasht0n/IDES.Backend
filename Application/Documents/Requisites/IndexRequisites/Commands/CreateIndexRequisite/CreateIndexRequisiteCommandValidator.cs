using FluentValidation;

namespace Application.Documents.Requisites.IndexRequisites.Commands.CreateIndexRequisite
{
    public class CreateIndexRequisiteCommandValidator:AbstractValidator<CreateIndexRequisiteCommand>
    {
        public CreateIndexRequisiteCommandValidator()
        {
            RuleFor(req => req.Value).NotEmpty();
        }
    }
}
