using System;
using Application.Common.Mapping;
using Application.Identity.Users.Commands;
using AutoMapper;

namespace WebApi.Models.Identity
{
    public class RegisterUserDto : IMapWith<RegisterUserCommand>
    {
        public Guid EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterUserDto, RegisterUserCommand>()
                .ForMember(command => command.EmployeeId, opt => opt.MapFrom(dto => dto.EmployeeId))
                .ForMember(command => command.Username, opt => opt.MapFrom(dto => dto.Username))
                .ForMember(command => command.Password, opt => opt.MapFrom(dto => dto.Password));
        }
    }
}
