using FluentValidation;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteDetails
{
    public class GetTitleRequisiteDetailsQueryValidator:AbstractValidator<GetTitleRequisiteDetailsQuery>
    {
        public GetTitleRequisiteDetailsQueryValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
