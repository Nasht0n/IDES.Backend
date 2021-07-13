using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.OrganizationStructure;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentDetails
{
    public class DepartmentDetailsVm:IMapWith<Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDetailsVm>()
                .ForMember(departmentVm => departmentVm.Name, opt => opt.MapFrom(department => department.Name))
                .ForMember(departmentVm=>departmentVm.IsDeleted, opt=>opt.MapFrom(department=>department.IsDeleted));
        }
    }
}
