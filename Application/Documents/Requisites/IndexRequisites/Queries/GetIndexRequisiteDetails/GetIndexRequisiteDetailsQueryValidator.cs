using FluentValidation;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteDetails
{
    public class GetIndexRequisiteDetailsQueryValidator:AbstractValidator<GetIndexRequisiteDetailsQuery>
    {
        public GetIndexRequisiteDetailsQueryValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
