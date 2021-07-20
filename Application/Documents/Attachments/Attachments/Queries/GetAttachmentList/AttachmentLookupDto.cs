using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Attachments;
using System;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentList
{
    public class AttachmentLookupDto:IMapWith<Attachment>
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public byte[] FileContent { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Attachment, AttachmentLookupDto>()
                .ForMember(dto => dto.Filename, opt => opt.MapFrom(attachment => attachment.Filename))
                .ForMember(dto => dto.Extension, opt => opt.MapFrom(attachment => attachment.Extension))
                .ForMember(dto => dto.FileContent, opt => opt.MapFrom(attachment => attachment.FileContent))
                .ForMember(dto => dto.IsDeleted, opt => opt.MapFrom(attachment => attachment.IsDeleted));
        }
    }
}
