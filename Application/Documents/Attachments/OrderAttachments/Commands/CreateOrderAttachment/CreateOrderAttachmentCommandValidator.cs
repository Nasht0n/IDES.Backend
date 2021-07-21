using FluentValidation;

namespace Application.Documents.Attachments.OrderAttachments.Commands.CreateOrderAttachment
{
    public class CreateOrderAttachmentCommandValidator:AbstractValidator<CreateOrderAttachmentCommand>
    {
        public CreateOrderAttachmentCommandValidator()
        {
            RuleFor(orderAttachment => orderAttachment.AttachmentId).NotEmpty();
            RuleFor(orderAttachment => orderAttachment.OrderDocumentId).NotEmpty();
        }
    }
}
