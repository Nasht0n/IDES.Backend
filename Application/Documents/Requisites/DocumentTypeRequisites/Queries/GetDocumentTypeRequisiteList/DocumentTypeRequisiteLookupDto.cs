using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteList
{
    public class DocumentTypeRequisiteLookupDto:IMapWith<DocumentTypeRequisite>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DocumentTypeRequisite, DocumentTypeRequisiteLookupDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(req => req.Id))
                .ForMember(dto => dto.IsDeleted, opt => opt.MapFrom(req => req.IsDeleted))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(req => req.Value));
        }
    }
}
