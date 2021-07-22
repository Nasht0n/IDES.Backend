using FluentValidation;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteList
{
    public class GetIndexRequisiteListQueryValidator:AbstractValidator<GetIndexRequisiteListQuery>
    {
        public GetIndexRequisiteListQueryValidator()
        {
            RuleFor(req => req.IsDeleted).NotEmpty();
        }
    }
}
