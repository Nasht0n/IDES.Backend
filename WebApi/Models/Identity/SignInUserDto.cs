using Application.Common.Mapping;
using Application.Identity.Users.Queries;
using AutoMapper;

namespace WebApi.Models.Identity
{
    public class SignInUserDto: IMapWith<SignInUserQuery>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SignInUserDto, SignInUserQuery>()
                .ForMember(query => query.Username, opt => opt.MapFrom(dto => dto.Username))
                .ForMember(query=>query.Password,opt=>opt.MapFrom(dto=>dto.Password));
        }
    }
}
