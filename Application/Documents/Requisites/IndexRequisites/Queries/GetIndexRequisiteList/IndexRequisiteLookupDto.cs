using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteList
{
    public class IndexRequisiteLookupDto:IMapWith<IndexRequisite>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IndexRequisite, IndexRequisiteLookupDto>()
                .ForMember(dto=>dto.Id,opt=>opt.MapFrom(req=>req.Id))
                .ForMember(dto => dto.Value, opt => opt.MapFrom(req => req.Value))
                .ForMember(dto => dto.IsDeleted, opt => opt.MapFrom(req => req.IsDeleted));
        }
    }
}
