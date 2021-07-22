using FluentValidation;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteList
{
    public class GetDateRequisiteListQueryValidator:AbstractValidator<GetDateRequisiteListQuery>
    {
        public GetDateRequisiteListQueryValidator()
        {
            RuleFor(req => req.IsDeleted).NotEmpty();
        }
    }
}
