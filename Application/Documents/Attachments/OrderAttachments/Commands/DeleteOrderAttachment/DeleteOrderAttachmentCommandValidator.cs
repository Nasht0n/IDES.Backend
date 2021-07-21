using FluentValidation;

namespace Application.Documents.Attachments.OrderAttachments.Commands.DeleteOrderAttachment
{
    public class DeleteOrderAttachmentCommandValidator:AbstractValidator<DeleteOrderAttachmentCommand>
    {
        public DeleteOrderAttachmentCommandValidator()
        {
            RuleFor(orderAttachment => orderAttachment.AttachmentId).NotEmpty();
            RuleFor(orderAttachment => orderAttachment.OrderDocumentId).NotEmpty();
        }
    }
}
