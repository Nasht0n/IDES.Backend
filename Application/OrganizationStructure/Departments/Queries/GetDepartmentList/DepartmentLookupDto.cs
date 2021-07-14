using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.OrganizationStructure;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentList
{
    public class DepartmentLookupDto:IMapWith<Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentLookupDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(department => department.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(department => department.Name));
        }
    }
}
