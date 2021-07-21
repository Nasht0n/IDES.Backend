using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Casts;

namespace Application.Documents.Casts.OrderCreators.Queries.GetOrderCreatorList
{
    public class OrderCreatorLookupDto:IMapWith<OrderCreator>
    {
        public Guid DocumentId { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderCreator, OrderCreatorLookupDto>()
                .ForMember(dto=>dto.EmployeeId, opt=>opt.MapFrom(oc=>oc.EmployeeId))
                .ForMember(dto=>dto.DocumentId, opt=>opt.MapFrom(oc=>oc.DocumentId));
        }
    }
}
