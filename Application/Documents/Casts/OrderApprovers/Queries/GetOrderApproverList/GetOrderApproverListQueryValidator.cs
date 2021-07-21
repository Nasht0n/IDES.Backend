using FluentValidation;

namespace Application.Documents.Casts.OrderApprovers.Queries.GetOrderApproverList
{
    public class GetOrderApproverListQueryValidator:AbstractValidator<GetOrderApproverListQuery>
    {
        public GetOrderApproverListQueryValidator()
        {
            RuleFor(oa => oa.OrderDocumentId).NotEmpty();
        }
    }
}
