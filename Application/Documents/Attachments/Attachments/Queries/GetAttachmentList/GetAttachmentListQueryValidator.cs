using FluentValidation;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentList
{
    public class GetAttachmentListQueryValidator:AbstractValidator<GetAttachmentListQuery>
    {
        public GetAttachmentListQueryValidator()
        {
            RuleFor(attachment => attachment.IsDeleted).NotEmpty();
        }
    }
}
