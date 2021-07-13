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
            profile.CreateMap<DepartmentLookupDto, Department>()
                .ForMember(departmentDto=>departmentDto.Id, opt=>opt.MapFrom(department=>department.Id))
                .ForMember(departmentDto => departmentDto.Name, opt => opt.MapFrom(department => department.Name));

        }
    }
}
