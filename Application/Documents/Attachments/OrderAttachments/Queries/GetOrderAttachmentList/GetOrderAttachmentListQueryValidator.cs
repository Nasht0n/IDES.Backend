using FluentValidation;

namespace Application.Documents.Attachments.OrderAttachments.Queries.GetOrderAttachmentList
{
    public class GetOrderAttachmentListQueryValidator:AbstractValidator<GetOrderAttachmentListQuery>
    {
        public GetOrderAttachmentListQueryValidator()
        {
            RuleFor(oa => oa.OrderDocumentId).NotEmpty();
        }
    }
}
