using System;
using Application.Common.Mapping;
using Application.OrganizationStructure.Employees.Commands.CreateEmployee;
using AutoMapper;

namespace WebApi.Models.OrganizationStructure
{
    public class CreateEmployeeDto : IMapWith<CreateEmployeeCommand>
    {
        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, CreateEmployeeCommand>()
                .ForMember(command => command.DepartmentId, opt => opt.MapFrom(dto => dto.DepartmentId))
                .ForMember(command=>command.Fullname,opt=>opt.MapFrom(dto=>dto.Fullname))
                .ForMember(command=>command.Position,opt=>opt.MapFrom(dto=>dto.Position))
                .ForMember(command=>command.Email,opt=>opt.MapFrom(dto=>dto.Email));

        }
    }
}
