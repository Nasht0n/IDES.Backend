using System;
using Application.Common.Mapping;
using Application.OrganizationStructure.Employees.Commands.UpdateEmployee;
using AutoMapper;

namespace WebApi.Models.OrganizationStructure
{
    public class UpdateEmployeeDto : IMapWith<UpdateEmployeeCommand>
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeDto, UpdateEmployeeCommand>()
                .ForMember(command => command.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(command => command.DepartmentId, opt => opt.MapFrom(dto => dto.DepartmentId))
                .ForMember(command => command.Fullname, opt => opt.MapFrom(dto => dto.Fullname))
                .ForMember(command => command.Position, opt => opt.MapFrom(dto => dto.Position))
                .ForMember(command => command.Email, opt => opt.MapFrom(dto => dto.Email))
                .ForMember(command => command.IsDeleted, opt => opt.MapFrom(dto => dto.IsDeleted));
        }
    }
}
