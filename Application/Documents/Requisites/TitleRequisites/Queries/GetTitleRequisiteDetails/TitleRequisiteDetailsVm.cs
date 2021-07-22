using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteDetails
{
    public class TitleRequisiteDetailsVm:IMapWith<TitleRequisite>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TitleRequisite, TitleRequisiteDetailsVm>()
                .ForMember(vm=>vm.Id,opt=>opt.MapFrom(req=>req.Id))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(req => req.Value))
                .ForMember(vm => vm.IsDeleted, opt => opt.MapFrom(req => req.IsDeleted));
        }
    }
}
