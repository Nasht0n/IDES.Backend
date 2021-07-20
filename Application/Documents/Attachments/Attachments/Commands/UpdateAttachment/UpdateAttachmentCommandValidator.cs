using FluentValidation;

namespace Application.Documents.Attachments.Attachments.Commands.UpdateAttachment
{
    public class UpdateAttachmentCommandValidator:AbstractValidator<UpdateAttachmentCommand>
    {
        public UpdateAttachmentCommandValidator()
        {
            RuleFor(attachment => attachment.Id).NotEmpty();
            RuleFor(attachment => attachment.File).NotEmpty().NotNull();
        }
    }
}
