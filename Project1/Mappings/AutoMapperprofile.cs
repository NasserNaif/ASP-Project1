using AutoMapper;
using Project1.Models.Domain;
using Project1.Models.DTO;

namespace Project1.Mappings
{
    public class AutoMapperprofiles : Profile
    {
        public AutoMapperprofiles()
        {
            // If the fields names is similair it will map it automatically 
            CreateMap<Region,RegionDto>().ReverseMap();


            // But if the fields diffrenet you have to map them by ForMember() method. to map the dto field to the model field
            CreateMap<User, UserDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.FullName))
            .ReverseMap()
            .ForMember(model => model.FullName, opt => opt.MapFrom(src => src.Name));
        }
    }

    public class User
    {
        public string FullName { get; set; }
    }

    public class UserDto
    {
        public string Name { get; set; }
    }
}
