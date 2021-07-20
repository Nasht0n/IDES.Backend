using FluentValidation;

namespace Application.Documents.Attachments.Attachments.Commands.DeleteAttachment
{
    public class DeleteAttachmentCommandValidator:AbstractValidator<DeleteAttachmentCommand>
    {
        public DeleteAttachmentCommandValidator()
        {
            RuleFor(attachment => attachment.Id).NotEmpty();
        }
    }
}
