using MediatR;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentList
{
    public class GetAttachmentListQuery:IRequest<AttachmentListVm>
    {
        public bool IsDeleted { get; set; }
    }
}
