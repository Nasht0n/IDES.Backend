using MediatR;
using System;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentDetails
{
    public class GetAttachmentDetailsQuery:IRequest<AttachmentDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
