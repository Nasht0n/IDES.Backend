using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.OrganizationStructure;

namespace Application.OrganizationStructure.Employees.Queries.GetEmployeeDetails
{
    public class EmployeeDetailsVm:IMapWith<Employee>
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsVm>()
                .ForMember(employeeVm => employeeVm.DepartmentId,
                    opt => opt.MapFrom(employee => employee.DepartmentId))
                .ForMember(employeeVm => employeeVm.Fullname,
                    opt => opt.MapFrom(employee => employee.Fullname))
                .ForMember(employeeVm => employeeVm.Position,
                    opt => opt.MapFrom(employee => employee.Position))
                .ForMember(employeeVm => employeeVm.Email,
                    opt => opt.MapFrom(employee => employee.Email))
                .ForMember(employeeVm => employeeVm.IsDelete,
                    opt => opt.MapFrom(employee => employee.IsDeleted));
        }
    }
}
