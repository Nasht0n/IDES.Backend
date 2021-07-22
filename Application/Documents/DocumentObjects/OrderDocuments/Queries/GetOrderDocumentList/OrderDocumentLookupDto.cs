using System;
using Application.Common.Mapping;
using Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentDetails;
using AutoMapper;
using Domain.Enums;
using Domain.Models.Documents.DocumentObjects;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentList
{
    public class OrderDocumentLookupDto:IMapWith<OrderDocument>
    {
        public Guid Id { get; set; }

        public Guid TitleId { get; set; }
        public Guid TypeId { get; set; }
        public Guid IndexId { get; set; }
        public Guid DateTimeId { get; set; }
        public DocumentState State { get; set; }

        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDocument, OrderDocumentVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(doc => doc.Id))
                .ForMember(vm => vm.TitleId, opt => opt.MapFrom(doc => doc.TitleId))
                .ForMember(vm => vm.TypeId, opt => opt.MapFrom(doc => doc.TypeId))
                .ForMember(vm => vm.IndexId, opt => opt.MapFrom(doc => doc.IndexId))
                .ForMember(vm => vm.DateTimeId, opt => opt.MapFrom(doc => doc.DateTimeId))
                .ForMember(vm => vm.State, opt => opt.MapFrom(doc => doc.State))
                .ForMember(vm => vm.IsDeleted, opt => opt.MapFrom(doc => doc.IsDeleted));
        }
    }
}
