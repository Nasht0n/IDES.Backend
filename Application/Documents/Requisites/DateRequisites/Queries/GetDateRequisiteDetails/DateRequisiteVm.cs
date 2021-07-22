using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteDetails
{
    public class DateRequisiteVm:IMapWith<DateRequisite>
    {
        public Guid Id { get; set; }
        public DateTime Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DateRequisite, DateRequisiteVm>()
                .ForMember(vm=>vm.Id,opt=>opt.MapFrom(req=>req.Id))
                .ForMember(vm=>vm.IsDeleted,opt=>opt.MapFrom(req=>req.IsDeleted))
                .ForMember(vm=>vm.Value,opt=>opt.MapFrom(req=>req.Value));
        }
    }
}
