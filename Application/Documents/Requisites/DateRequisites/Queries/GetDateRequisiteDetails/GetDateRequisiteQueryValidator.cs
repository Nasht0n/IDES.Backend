using FluentValidation;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteDetails
{
    public class GetDateRequisiteQueryValidator:AbstractValidator<GetDateRequisiteQuery>
    {
        public GetDateRequisiteQueryValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
