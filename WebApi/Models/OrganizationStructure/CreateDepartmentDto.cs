using Application.Common.Mapping;
using Application.OrganizationStructure.Departments.Commands.CreateDepartment;
using AutoMapper;

namespace WebApi.Models.OrganizationStructure
{
    public class CreateDepartmentDto:IMapWith<CreateDepartmentCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentDto, CreateDepartmentCommand>()
                .ForMember(command => command.Name, opt => opt.MapFrom(dto => dto.Name));
        }
    }
}
