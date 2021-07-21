using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Casts;

namespace Application.Documents.Casts.OrderApprovers.Queries.GetOrderApproverList
{
    public class OrderApproverLookupDto:IMapWith<OrderApprover>
    {
        public Guid DocumentId { get; set; }
        public Guid EmployeeId { get; set; }
        public int Rank { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderApprover, OrderApproverLookupDto>()
                .ForMember(dto=>dto.EmployeeId, opt=>opt.MapFrom(oa=>oa.EmployeeId))
                .ForMember(dto=>dto.DocumentId, opt=>opt.MapFrom(oa=>oa.DocumentId))
                .ForMember(dto=>dto.Rank, opt=>opt.MapFrom(oa=>oa.Rank));

        }
    }
}
