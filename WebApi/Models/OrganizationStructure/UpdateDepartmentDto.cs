using System;
using Application.Common.Mapping;
using Application.OrganizationStructure.Departments.Commands.UpdateDepartment;
using AutoMapper;

namespace WebApi.Models.OrganizationStructure
{
    public class UpdateDepartmentDto:IMapWith<UpdateDepartmentCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentDto, UpdateDepartmentCommand>()
                .ForMember(command =>command.Id,opt=>opt.MapFrom(dto=>dto.Id))
                .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(command=>command.IsDeleted, opt=>opt.MapFrom(dto=>dto.IsDeleted));
        }
    }
}
