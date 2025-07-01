using AutoMapper;
using EmployeeProject.DTO;
using EmployeeProject.Models;

namespace EmployeeProject.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<AddEmployeeRequestDto, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeRequestDto, Employee>().ReverseMap();

            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<AddSkillRequestDto, Skill>().ReverseMap();
            CreateMap<UpdateSkillRequestDto, Skill>().ReverseMap();

            CreateMap<EmployeeSkill, EmployeeSkillDto>()
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.SkillName))
                .ReverseMap()
                .ForMember(dest => dest.Skill, opt => opt.Ignore()); // Ignore Skill to prevent circular reference
            CreateMap<AddEmployeeSkillRequestDto, EmployeeSkill>();
           
        }
    }
}
