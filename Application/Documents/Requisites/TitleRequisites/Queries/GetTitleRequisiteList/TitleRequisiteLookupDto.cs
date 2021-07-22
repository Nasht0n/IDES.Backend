using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteList
{
    public class TitleRequisiteLookupDto:IMapWith<TitleRequisite>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TitleRequisite, TitleRequisiteLookupDto>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(req => req.Id))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(req => req.Value))
                .ForMember(vm => vm.IsDeleted, opt => opt.MapFrom(req => req.IsDeleted));
        }
    }
}
