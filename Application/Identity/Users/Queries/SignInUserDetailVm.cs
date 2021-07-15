using System;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Models.Identity;

namespace Application.Identity.Users.Queries
{
    public class SignInUserDetailVm:IMapWith<AppUser>
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppUser, SignInUserDetailVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(user => Guid.Parse(user.Id)))
                .ForMember(vm=>vm.EmployeeId,opt=>opt.MapFrom(user=>user.EmployeeId));
        }
    }
}
