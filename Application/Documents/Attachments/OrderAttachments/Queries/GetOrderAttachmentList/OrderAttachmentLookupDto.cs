using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Attachments;

namespace Application.Documents.Attachments.OrderAttachments.Queries.GetOrderAttachmentList
{
    public class OrderAttachmentLookupDto:IMapWith<OrderAttachment>
    {
        public Guid AttachmentId { get; set; }
        public Guid OrderDocumentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderAttachment, OrderAttachmentLookupDto>()
                .ForMember(vm => vm.AttachmentId, opt => opt.MapFrom(oa => oa.AttachmentId))
                .ForMember(vm=>vm.OrderDocumentId,opt=>opt.MapFrom(oa=>oa.OrderDocumentId));
        }
    }
}
