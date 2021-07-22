using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Documents.Requisites;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteDetails
{
    public class DocumentTypeRequisiteVm:IMapWith<DocumentTypeRequisite>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DocumentTypeRequisite, DocumentTypeRequisiteVm>()
                .ForMember(vm=>vm.Id, opt=>opt.MapFrom(req=>req.Id))
                .ForMember(vm=>vm.IsDeleted,opt=>opt.MapFrom(req=>req.IsDeleted))
                .ForMember(vm=>vm.Value,opt=>opt.MapFrom(req=>req.Value));
        }
    }
}
