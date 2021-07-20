using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Attachments;
using System;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentDetails
{
    public class AttachmentDetailsVm:IMapWith<Attachment>
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public byte[] FileContent { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attachment, AttachmentDetailsVm>()
                .ForMember(attachmentVm => attachmentVm.Filename, opt => opt.MapFrom(attachment => attachment.Filename))
                .ForMember(attachmentVm => attachmentVm.Extension, opt => opt.MapFrom(attachment => attachment.Extension))
                .ForMember(attachmentVm => attachmentVm.FileContent, opt => opt.MapFrom(attachment => attachment.FileContent))
                .ForMember(attachmentVm => attachmentVm.IsDeleted, opt => opt.MapFrom(attachment => attachment.IsDeleted));
        }
    }
}
