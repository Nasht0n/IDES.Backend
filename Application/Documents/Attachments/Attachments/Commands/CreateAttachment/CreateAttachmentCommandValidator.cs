using FluentValidation;

namespace Application.Documents.Attachments.Attachments.Commands.CreateAttachment
{
    public class CreateAttachmentCommandValidator:AbstractValidator<CreateAttachmentCommand>
    {
        public CreateAttachmentCommandValidator()
        {
            RuleFor(attachment => attachment.File).NotNull().NotEmpty();
        }
    }
}
