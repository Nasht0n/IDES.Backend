using FluentValidation;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteList
{
    public class GetTitleRequisiteListQueryValidator:AbstractValidator<GetTitleRequisiteListQuery>
    {
        public GetTitleRequisiteListQueryValidator()
        {
            RuleFor(req => req.IsDelete).NotEmpty();
        }
    }
}
