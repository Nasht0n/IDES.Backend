using FluentValidation;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentDetails
{
    public class GetAttachmentDetailsQueryValidator:AbstractValidator<GetAttachmentDetailsQuery>
    {
        public GetAttachmentDetailsQueryValidator()
        {
            RuleFor(attachment => attachment.Id).NotEmpty();
        }
    }
}
