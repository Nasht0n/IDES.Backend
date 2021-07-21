using FluentValidation;

namespace Application.Documents.Casts.OrderCreators.Queries.GetOrderCreatorList
{
    public class GetOrderCreatorListQueryValidator:AbstractValidator<GetOrderCreatorListQuery>
    {
        public GetOrderCreatorListQueryValidator()
        {
            RuleFor(oc => oc.OrderDocumentId).NotEmpty();
        }
    }
}
