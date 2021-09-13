using Application.Common.Mapping;
using Application.Documents.Attachments.Attachments.Commands.CreateAttachment;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace WebApi.Models.Attachments
{
    public class CreateAttachmentDto:IMapWith<CreateAttachmentCommand>
    {
        public IFormFile File { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAttachmentDto, CreateAttachmentCommand>().ForMember(command => command.File, opt=>opt.MapFrom(dto=>dto.File));
        }
    }
}
