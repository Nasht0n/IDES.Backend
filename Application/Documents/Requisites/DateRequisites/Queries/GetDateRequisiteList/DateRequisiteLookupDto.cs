using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteList
{
    public class DateRequisiteLookupDto:IMapWith<DateRequisite>
    {
        public Guid Id { get; set; }
        public DateTime Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DateRequisite, DateRequisiteLookupDto>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(req => req.Id))
                .ForMember(vm => vm.IsDeleted, opt => opt.MapFrom(req => req.IsDeleted))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(req => req.Value));
        }
    }
}
