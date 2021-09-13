using Application.Common.Mapping;
using Application.Documents.Attachments.Attachments.Commands.UpdateAttachment;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;

namespace WebApi.Models.Attachments
{
    public class UpdateAttachmentDto : IMapWith<UpdateAttachmentCommand>
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAttachmentDto, UpdateAttachmentCommand>()
                .ForMember(command => command.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.File, opt => opt.MapFrom(dto => dto.File))
                .ForMember(command => command.IsDeleted, opt => opt.MapFrom(dto => dto.IsDeleted));
        }
    }
}
